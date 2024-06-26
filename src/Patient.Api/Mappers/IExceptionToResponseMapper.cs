using Patient.Api.Models;

namespace Patient.Api.Mappers;

public interface IExceptionToResponseMapper
{
    ExceptionResponse Map(Exception exception);
}