using FluentResults;

namespace ShareRegister.Domain.Common.Errors;
public class RequiredError : Error
{
    public string FieldName { get; private set; }

    public RequiredError(string fieldName)
        : base($"{fieldName} is required.")
    {
        FieldName = fieldName;
        Metadata.Add("ErrorCode", 100);
    }
}