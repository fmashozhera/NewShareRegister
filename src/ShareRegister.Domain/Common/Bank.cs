using FluentResults;
using System.Runtime.InteropServices;

namespace ShareRegister.Domain.Common;

public class Bank : AuditableEntity
{
    public string BankCode { get; set; }
    public string Name { get; set; }
    public Address Address { get; set; }
    public ISet<TelephoneNumber> TelephoneNumbers { get; set; }
    public IEnumerable<BankBranch> Branches { get; set; } = new List<BankBranch>();

    [assembly: InternalsVisibleTo("ShareRegister.Data")]
    public Bank()
    {
            
    }

    private Bank(string bankCode, string name, Address address, ISet<TelephoneNumber> telephoneNumbers)
    {
        BankCode = bankCode;
        Name = name;
        Address = address;
        TelephoneNumbers = telephoneNumbers;   
    }

    private static Result<Bank> SetBank(string bankCode, string name, Address address, ISet<TelephoneNumber> telephoneNumbers)
    {
        Result result = ValidateBankParameters(bankCode, name, address, telephoneNumbers);
        if (result.IsSuccess)
        {
            Bank bank = new Bank(bankCode, name, address, telephoneNumbers);
            return bank;
        }
        return result;
    }

    public static Result<Bank> Create(string bankCode, string name, Address address, ISet<TelephoneNumber> telephoneNumbers)
    {
        Result<Bank> result = SetBank(bankCode, name, address, telephoneNumbers);
        return result;
    }

    private static Result ValidateBankParameters(string bankCode, string name,Address address, ISet<TelephoneNumber> telephoneNumbers)
    {
        return Result.Merge( 
            Result.FailIf(String.IsNullOrWhiteSpace(bankCode),"Bank code is required."),
            Result.FailIf(String.IsNullOrWhiteSpace(name),"Bank name is required."),
            Result.FailIf(address is null,"Address is required."),
            Result.FailIf(telephoneNumbers is null || telephoneNumbers.Count()==0,"Provide at least one telephone number.")
            );
    }

    public Result<BankBranch> AddBranch(string branchName,string branchCode)
    {
        Result<BankBranch> bankBranchResult = BankBranch.Create(branchName,branchCode);
        if(bankBranchResult.IsSuccess)
        {
            ICollection<BankBranch> branchesList = Branches.ToList();
            branchesList.Add(bankBranchResult.Value);
            Branches = branchesList;            
        }

        return bankBranchResult;
    }
}
