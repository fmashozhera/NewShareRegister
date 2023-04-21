namespace ShareRegister.Domain.Common;
public class OrganisationalInvestor : Investor
{
    public string FullName { get; set; }   
    public InvestorType InvestorType { get => InvestorType.Organisation; }    
}
