using Patient.Application.Searches;

namespace Patient.Api.Parsers;

public interface ISearchBirthDateParser
{
    (SearchOperation, DateSearch) Parse(string search);
}