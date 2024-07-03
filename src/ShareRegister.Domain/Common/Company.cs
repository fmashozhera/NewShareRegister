using FluentResults;
using ShareRegister.Domain.Common.Errors;
using ShareRegister.Domain.Common.Interfaces;

namespace ShareRegister.Domain.Common;
public class Company : AuditableEntity, IContactable
{
    private ISet<TelephoneNumber> _telephoneNumbers = new HashSet<TelephoneNumber>();
    public string CompanyCode { get; private set; }
    public string Name { get; private set; }
    public string ISIN { get; private set; }

    public Address Address { get; private set; }
    public Email Email { get; private set; }
    public ISet<TelephoneNumber> TelephoneNumbers { get => _telephoneNumbers; }

    [assembly: InternalsVisibleTo("ShareRegister.Data")]
    [assembly: InternalsVisibleTo("ShareRegister.Application.Tests")]
    internal Company()
    {

    }

    internal Company(string companyCode,
        string name,
        string iSIN,
        Address address,
        Email email,
        ISet<TelephoneNumber> telephoneNumbers)
    {
        CompanyCode = companyCode;
        Name = name;
        ISIN = iSIN;
        Address = address;
        Email = email;
        _telephoneNumbers = telephoneNumbers;
    }

    public static Result<Company> Create(string companyCode, string name, string Isin, Address address, Email email, ISet<TelephoneNumber> telephoneNumbers)
    {
        Result validationResult = ValidateCompanyParameters(companyCode, name, Isin, address, email, telephoneNumbers);

        if (validationResult.IsSuccess)
            return new Company(companyCode, name, Isin, address, email, telephoneNumbers);
        else
            return validationResult;
    }

    public Result<Company> Delete()
    {
        base.Delete();
        return Result.Ok();
    }

    public Result<Company> Update(string companyCode, string name, string Isin, Address address, Email email, ISet<TelephoneNumber> telephoneNumbers)
    {
        base.Update();
        Result validationResult = ValidateCompanyParameters(companyCode, name, Isin, address, email, telephoneNumbers);

        if (validationResult.IsSuccess)
        {
            CompanyCode = companyCode;
            Name = name;
            ISIN = Isin;
            Address = address;
            Email = email;
            _telephoneNumbers = telephoneNumbers;
            return this;
        }
        else
        {
            return validationResult;
        }
    }

    private static Result ValidateCompanyParameters(string companyCode, string name, string Isin, Address address, Email email, ISet<TelephoneNumber> telephoneNumbers)
    {
        return Result.Merge(
            Result.FailIf(address is null, "Address is required."),
            Result.FailIf(email is null, "Email is required."),
            Result.FailIf(telephoneNumbers is null || telephoneNumbers.Count() == 0, "Telephone numbers are required."),
            Result.FailIf(String.IsNullOrWhiteSpace(companyCode), new RequiredError("CompanyCode")),
            Result.FailIf(String.IsNullOrWhiteSpace(name), new RequiredError("Name")),
            Result.FailIf(String.IsNullOrWhiteSpace(Isin), new RequiredError("ISIN"))
            ); ;
    }
}

