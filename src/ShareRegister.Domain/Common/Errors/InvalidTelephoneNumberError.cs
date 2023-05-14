using FluentResults;

namespace ShareRegister.Domain.Common.Errors;
public class InvalidTelephoneNumberError : Error
{
    public InvalidTelephoneNumberError() : base("Invalid telephone number.")
    {        
    }
}
