using Patient.Api.Exceptions;
using Patient.Application.Searches;

namespace Patient.Api.Parsers;

public sealed class SearchBirthDateParser : ISearchBirthDateParser
{
    public (SearchOperation, DateSearch) Parse(string search)
    {
        search = search.Trim();

        if (string.IsNullOrWhiteSpace(search))
        {
            throw new SearchStringIsNullOrEmptyException();
        }

        if (search.Length < 12)
        {
            throw new InvalidSearchStringException();
        }

        var operationString = search.Substring(0, 2);

        if (!Enum.TryParse<SearchOperation>(operationString, true, out var operation))
        {
            throw new InvalidSearchOperationException(operationString);
        }

        var dateString = search.Substring(2);

        if (!DateSearch.TryParse(dateString, out var date))
        {
            throw new InvalidSearchDateException(dateString);
        }

        return (operation, date);
    }
}