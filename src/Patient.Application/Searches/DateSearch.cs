namespace Patient.Application.Searches;

public struct DateSearch
{
    private const int DateLength = 10;

    private DateTime value;
    public bool IsDateOnly { get; }

    public DateSearch(DateTime value, bool isDateOnly)
    {
        this.value = value;
        IsDateOnly = isDateOnly;
    }

    public DateTime GetDateTime() => value;
    public DateOnly GetDateOnly() => DateOnly.FromDateTime(value);

    public static bool TryParse(string? value, out DateSearch dateSearch)
    {
        dateSearch = new DateSearch(DateTime.MinValue, false);

        if (string.IsNullOrWhiteSpace(value) || value.Length < DateLength)
        {
            return false;
        }

        var isParsed = DateTime.TryParse(value, out var date);

        if (value.Length == DateLength && isParsed)
        {
            dateSearch = new DateSearch(date, true);

            return true;
        }

        if (isParsed)
        {
            dateSearch = new DateSearch(date, false);

            return true;
        }

        return false;
    }
}