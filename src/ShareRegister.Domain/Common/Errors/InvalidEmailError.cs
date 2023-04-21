using FluentResults;

namespace ShareRegister.Domain.Common.Errors;
public class InvalidEmailError : Error
{
	public InvalidEmailError():base("Invalid email format.")
	{		
	}
}
