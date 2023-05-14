using FluentResults;
using ShareRegister.Domain.Common.Errors;
using System.Text.RegularExpressions;

namespace ShareRegister.Domain.Common;
public record TelephoneNumber
{    
    public string Value { get; private set; }
    public TelephoneNumberType TelephoneNumberType { get; private set; }

    private TelephoneNumber(string telephoneNumber,TelephoneNumberType type)
    {
        this.Value = telephoneNumber;
        this.TelephoneNumberType = type;
    }

    public static Result<TelephoneNumber> Create(string telephoneNumber, TelephoneNumberType telephoneNumberType)
    {
        var validationResult = Result.Merge(
            Result.FailIf(String.IsNullOrWhiteSpace(telephoneNumber), new RequiredError("TelephoneNumber")),
            Result.FailIf(!IsTelephoneNumberValid(telephoneNumber), new InvalidTelephoneNumberError())
            );

        if (validationResult.IsSuccess)
            return new TelephoneNumber(telephoneNumber, telephoneNumberType);
        else
            return validationResult;
    }

    private static bool IsTelephoneNumberValid(string telephoneNumber)
    {
        var mapper = @"^" + Regex.Escape("+") + @"?\d*$";
        var isMatch = Regex.Match(telephoneNumber, mapper).Success;
        return isMatch;
    }
}
