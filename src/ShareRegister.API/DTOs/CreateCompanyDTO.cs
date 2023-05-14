namespace ShareRegister.API.DTOs;

public class CreateCompanyDTO
{
    public string CompanyCode { get; set; }
    public string Name { get; set; }
    public string ISIN { get; set; }
    public string Street { get; set; }
    public string Surburb { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}
