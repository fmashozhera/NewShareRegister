using FluentResults;
using ShareRegister.Domain.Common.Errors;
using System.Runtime.CompilerServices;

namespace ShareRegister.Domain.Common;
public class Address
{
    public Guid Id { get; private set; }
    public string Street { get; private set; }
    public string Surburb { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }
    public string PostalCode { get; private set; }

    private Address(
        string street,
        string surburb,
        string city,
        string country,
        string postalCode)
    {
        Id = Guid.NewGuid();
        this.Street = street;
        this.Surburb = surburb;
        this.City = city;
        this.Country = country;
        this.PostalCode = postalCode;
    }

    public static Result<Address> Create(string street,
        string surburb,
        string city,
        string country,
        string postalCode)
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

    public Result<Address> Update(string street,
        string surburb,
        string city,
        string country,
        string postalCode)
    {
        Result validationResult = ValidateAddressInput(street, surburb, city, country);

        if (validationResult.IsFailed)
        {
            validationResult.Reasons.Add(new InvalidAddressError());
            return validationResult;
        }

        this.Street = street;
        this.Surburb = surburb;
        this.City = city;
        this.Country = country;
        this.PostalCode = postalCode;
        return this;
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
}
