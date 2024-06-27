using Patient.Api.Exceptions;
using Patient.Api.Models;
using Patient.Application.Exceptions;
using Patient.Core.Exceptions;

namespace Patient.Api.Mappers;

public sealed class ExceptionToResponseMapper : IExceptionToResponseMapper
{
    public ExceptionResponse Map(Exception exception) => exception switch
    {
        DomainException ex => new ExceptionResponse(ex.Message, 400),
        PatientNotFoundException ex => new ExceptionResponse(ex.Message, 404),
        ResourceAlreadyExistsException ex => new ExceptionResponse(ex.Message, 400),
        SearchStringIsNullOrEmptyException ex => new ExceptionResponse(ex.Message, 400),
        InvalidSearchStringException ex => new ExceptionResponse(ex.Message, 400),
        InvalidSearchOperationException ex => new ExceptionResponse(ex.Message, 400),
        InvalidSearchDateException ex => new ExceptionResponse(ex.Message, 400),
        _ => new ExceptionResponse("Internal error", 500)
    };
}