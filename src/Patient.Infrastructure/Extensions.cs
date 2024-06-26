using Microsoft.Extensions.DependencyInjection;
using Patient.Application.Services;
using Patient.Infrastructure.Mongo.Repositories;

namespace Patient.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IPatientRepository, PatientMongoRepository>();

        return services;
    }
}