using FluentResults;
using ShareRegister.Domain.Common.Errors;

namespace ShareRegister.Domain.Common;
public record Address
{
    public string Street { get; private set; }
    public string Surburb { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }
    public string PostalCode { get; private set; }

    [assembly: InternalsVisibleTo("ShareRegister.Application.Tests")]
    [assembly: InternalsVisibleTo("ShareRegister.Core.Tests.StepDefinitions")]
    internal Address(string street, string surburb, string city, string country, string postalCode)
    {    
        this.Street = street;
        this.Surburb = surburb;
        this.City = city;
        this.Country = country;
        this.PostalCode = postalCode;
    }

    public static Result<Address> Create(string street, string surburb, string city, string country, string postalCode)
    {
        Result<Address> Address = SetAddress(street, surburb, city, country, postalCode);
        return Address;
    }

    public Result<Address> Update(string street, string surburb, string city, string country, string postalCode)
    {       
        Result<Address> Address = SetAddress(street, surburb, city, country, postalCode);
        return Address;
    }

    private static Result ValidateAddressInput(string street, string surburb, string city, string country)
    {
        var validationResult = new Result();
        if (string.IsNullOrWhiteSpace(street))
            validationResult.Reasons.Add(new RequiredError("Street"));
        if (string.IsNullOrWhiteSpace(surburb))
            validationResult.Reasons.Add(new RequiredError("Surburb"));
        if (string.IsNullOrWhiteSpace(city))
            validationResult.Reasons.Add(new RequiredError("City"));
        if (string.IsNullOrWhiteSpace(country))
            validationResult.Reasons.Add(new RequiredError("Country"));

        return validationResult;
    }

    private static Result<Address> SetAddress(string street, string surburb, string city, string country, string postalCode)
    {
        Result validationResult = ValidateAddressInput(street, surburb, city, country);

        if (validationResult.IsFailed)
        {
            validationResult.Reasons.Add(new InvalidAddressError());
            return validationResult;
        }

        var Address = new Address(street, surburb, city, country, postalCode);
        return Address;
    }
}
