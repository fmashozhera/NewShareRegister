using FluentResults;

namespace ShareRegister.Domain.Common;
public class Broker : AuditableEntity
{
    public string BrokerCode { get; private set; }
    public string Name { get; private set; }
    public Address Address { get; private set; }
    public ICollection<TelephoneNumber> TelephoneNumbers { get; private set; } = new List<TelephoneNumber>();

    private Broker(string brokerCode, string brokerName, Address address, ISet<TelephoneNumber> telephoneNumbers)
    {
        this.BrokerCode = brokerCode;
        this.Name= brokerName;
        this.Address = address;
        this.TelephoneNumbers = telephoneNumbers;
    }

    public static Result<Broker> Create(string brokerCode, string brokerName, Address address, ISet<TelephoneNumber> telephoneNumbers)
    {
        Result<Broker> validationResult = ValidateBrokerInformation(brokerCode, brokerName, address, telephoneNumbers);
        if (validationResult.IsSuccess)
        {
            Broker broker = new Broker(brokerCode,brokerName, address, telephoneNumbers);
            return broker;
        }
        return validationResult;
    }

    private static Result<Broker> ValidateBrokerInformation(string brokerCode, string brokerName, Address address, ISet<TelephoneNumber> telephoneNumbers)
    {
        return Result.Merge(
            Result.FailIf(String.IsNullOrWhiteSpace(brokerCode),"Broker code is required."),
            Result.FailIf(String.IsNullOrWhiteSpace(brokerName),"Broker name is required."),
            Result.FailIf(address is null,"Broker address is required."),
            Result.FailIf(telephoneNumbers is null || telephoneNumbers.Count()==0,"Enter at least one telephone number.")
            );
    }

    public Result<Broker> Update(string brokerCode, string brokerName, Address address, ISet<TelephoneNumber> telephoneNumbers)
    {
        Result<Broker> validationResult = ValidateBrokerInformation(brokerCode, brokerName, address, telephoneNumbers);
        if (validationResult.IsSuccess)
        {
            this.BrokerCode = brokerCode;
            this.Name = brokerName;
            this.Address = address;
            this.TelephoneNumbers = telephoneNumbers;
            return this;
        }
        return validationResult;
    }
}
