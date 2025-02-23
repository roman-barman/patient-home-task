using MediatR;
using Microsoft.AspNetCore.Mvc;
using Patient.Api.Mappers;
using Patient.Api.Parsers;
using Patient.Application;
using Patient.Application.Commands;
using Patient.Application.DTO;
using Patient.Application.Queries;
using Patient.Infrastructure;
using Patient.Infrastructure.Mongo.Settings;
using Swashbuckle.AspNetCore.Annotations;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .Configure<PatientMongoRepositorySetting>(builder.Configuration.GetSection("PatientMongoRepository"));

builder.Services.AddSingleton<IExceptionToResponseMapper, ExceptionToResponseMapper>();
builder.Services.AddSingleton<ISearchBirthDateParser, SearchBirthDateParser>();

builder.Services
    .AddHealthChecks()
    .AddMongoDb(builder.Configuration["PatientMongoRepository:ConnectionURI"]);

builder.Services
    .AddApplication()
    .AddInfrastructure();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = builder.Environment.ApplicationName,
        Version = "v1"
    });
});

var app = builder.Build();

app.Use(async (context, next) =>
{
    try
    {
        await next(context);
    }
    catch (Exception ex)
    {
        var response = context.RequestServices.GetRequiredService<IExceptionToResponseMapper>().Map(ex);
        context.Response.StatusCode = response.StatusCode;
        context.Response.ContentType = Text.Plain;
        await context.Response.WriteAsync(response.Message);
    }
});

app.MapHealthChecks("/healthz");

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                                $"{builder.Environment.ApplicationName} v1"));

app.MapPost("/patients", async (PatientDTO patient, IMediator mediator) =>
{
    var id = await mediator.Send(new AddPatientCommand(patient));
    var response = await mediator.Send(new GetPatientQuery(id));

    return Results.Created($"/patients/{id}", response);
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Create patient"));

app.MapPut("/patients/{id}", async (Guid id, PatientDTO patient, IMediator mediator) =>
{
    var isUpdated = await mediator.Send(new AddOrUpdatePatientCommand(patient, id));
    var response = await mediator.Send(new GetPatientQuery(id));

    return isUpdated ? Results.Ok(response) : Results.Created($"/patients/{id}", response);
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Update or create patient"));

app.MapGet("/patients/{id}", async (Guid id, IMediator mediator) =>
{
    var patient = await mediator.Send(new GetPatientQuery(id));

    return Results.Ok(patient);
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Get patient by ID"));

app.MapDelete("/patients/{id}", async (Guid id, IMediator mediator) =>
{
    await mediator.Send(new DeletePatientCommand(id));

    return Results.NoContent();
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Delete patient"));

app.MapGet("/patients", async ([FromQuery(Name = "birthDate")] string birthDateSearch, ISearchBirthDateParser searchParser, IMediator mediator) =>
{
    var (searchOpeartion, date) = searchParser.Parse(birthDateSearch);
    var patients = await mediator.Send(new GetPatientByBirthDateQuery(searchOpeartion, date));

    return Results.Ok(patients);
})
.WithMetadata(new SwaggerOperationAttribute(summary: "Find patients by birth date"));

app.Run();
