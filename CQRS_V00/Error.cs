namespace CQRS_V00;

public record Error(string Code, string Description, int? statusCodes)
{
    public static readonly Error Non = new(string.Empty, string.Empty, null);
}
