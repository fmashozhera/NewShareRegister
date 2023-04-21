using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareRegister.Domain.Common.Errors;
public class InvalidAddressError : Error
{
	public InvalidAddressError() : base("Address is invalid.")
	{

	}
}
