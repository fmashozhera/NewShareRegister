using FluentResults;
using ShareRegister.Domain.Common.Errors;
using System.Text.RegularExpressions;

namespace ShareRegister.Domain.Common;
public record TelephoneNumber
{    
    public string Value { get; private set; }
    public TelephoneNumberType TelephoneNumberType { get; private set; }

    [assembly: InternalsVisibleTo("ShareRegister.Data")]
    internal TelephoneNumber()
    {
            
    }
    [assembly: InternalsVisibleTo("ShareRegister.Application.Tests")]
    [assembly: InternalsVisibleTo("ShareRegister.Core.Tests.StepDefinitions")]
    internal TelephoneNumber(string telephoneNumber,TelephoneNumberType type)
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

    public static Result<IEnumerable<TelephoneNumber>> CreateTelephoneNumbers(IDictionary<string, TelephoneNumberType> telephoneNumbers)
    {
        List<TelephoneNumber> createdTelephoneNumbers = new List<TelephoneNumber>();
        Result<IEnumerable<TelephoneNumber>> telephoneNumbersCreationResult = new Result<IEnumerable<TelephoneNumber>>();
        foreach (KeyValuePair<string, TelephoneNumberType> telephoneNumber in telephoneNumbers)
        {
            Result<TelephoneNumber> telephoneNumberCreationResult = TelephoneNumber.Create(telephoneNumber.Key.ToString(), (TelephoneNumberType)telephoneNumber.Value);
            if (telephoneNumberCreationResult.IsSuccess)
            {
                createdTelephoneNumbers.Add(telephoneNumberCreationResult.Value);
            }
            else
            {
                telephoneNumbersCreationResult.Reasons.AddRange(telephoneNumberCreationResult.Reasons);
            }
        }

        return telephoneNumbersCreationResult.IsSuccess ? createdTelephoneNumbers : telephoneNumbersCreationResult;
    }
}
