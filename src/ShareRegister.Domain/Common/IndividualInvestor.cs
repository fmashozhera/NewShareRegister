namespace ShareRegister.Domain.Common;
public class IndividualInvestor : Investor
{
    public string FullName { get => $"{Title} {FirstName} {LastName}"; }
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public InvestorType InvestorType { get => InvestorType.Individual; }    
}
