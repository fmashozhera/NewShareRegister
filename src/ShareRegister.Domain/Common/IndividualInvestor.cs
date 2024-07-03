using FluentResults;

namespace ShareRegister.Domain.Common;
public class IndividualInvestor : Investor
{
    public string FullName { get => $"{Title} {FirstName} {LastName}"; }
    public string Title { get;private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public InvestorType InvestorType { get => InvestorType.Individual; }

    private IndividualInvestor(string title, string firstName, string lastame, string identificationNumber, IdentificationType identificationType, Address address, Email email, TelephoneNumber telephoneNumber)
    {
        this.Title = title;
        this.FirstName = firstName;
        this.LastName = lastame;
        this.IdentificationNumber = identificationNumber;
        this.IdentificationType = identificationType;
        this.Address = address;
        this.Email = email;
        this.TelephoneNumber = telephoneNumber;        
    }

    public static Result<IndividualInvestor> Create(string title, string firstName, string surname, string identificationNumber, IdentificationType identificationType, Address address, Email email, TelephoneNumber telephoneNumber)
    {
        IndividualInvestor individualInvestor = new IndividualInvestor(title, firstName, surname, identificationNumber, identificationType, address, email, telephoneNumber);
        return individualInvestor;
    }
}
