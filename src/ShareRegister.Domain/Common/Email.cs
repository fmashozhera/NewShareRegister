using FluentResults;
using ShareRegister.Domain.Common.Errors;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ShareRegister.Domain.Common;
public class Email
{
    public string Value { get; private set; }

    [assembly: InternalsVisibleTo("ShareRegister.Application.Tests")]
    [assembly: InternalsVisibleTo("ShareRegister.Core.Tests.StepDefinitions")]
    internal Email(string value)
    {
        this.Value = value;
    }
    public static Result<Email> Create(string value)
    {
        var validationResult = Result.Merge(
            Result.FailIf(String.IsNullOrWhiteSpace(value),new RequiredError("Email")),
            Result.FailIf(!IsValidEmail(value),new InvalidEmailError())
            );

        if(validationResult.IsSuccess)
        {
            return new Email(value);
        }
        else
        {
            return validationResult;
        }
    }

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,RegexOptions.None, TimeSpan.FromMilliseconds(200));

            // Examines the domain part of the email and normalizes it.
            string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
        catch (ArgumentException e)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}
