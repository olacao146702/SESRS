namespace SESRS.Helpers;

/// <summary>
/// A problem the user can fix (validation, duplicate, blocked action).
/// Its message is safe to display as-is.
/// </summary>
public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message) : base(message)
    {
    }
}
