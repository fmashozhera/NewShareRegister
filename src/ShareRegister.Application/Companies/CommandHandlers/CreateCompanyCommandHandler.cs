using AutoMapper;
using FluentResults;
using ShareRegister.Application.Companies.Commands;
using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Application.Companies.Queries;
using ShareRegister.Application.Interfaces.Common;
using ShareRegister.Domain.Common;

namespace ShareRegister.Application.Companies.CommandHandlers;

public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, CompanyDto>
{
    private readonly ICompanyRepository _companies;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCompanyCommandHandler(ICompanyRepository companies, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _companies = companies;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<CompanyDto>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        CreateCompanyDto companyData = request.CompanyData;
        Result<Address> companyAddressResult = Address.Create(companyData.Street, companyData.Surburb, companyData.City, companyData.Country, companyData.PostalCode);
        Result<Email> companyEmailResult = Email.Create(companyData.Email);
        Result<IEnumerable<TelephoneNumber>> telephoneNumberResult = TelephoneNumber.CreateTelephoneNumbers(companyData.TelephoneNumbers);

        if (telephoneNumberResult.IsFailed || companyAddressResult.IsFailed || companyEmailResult.IsFailed)
        {
            IEnumerable<IError> errors = new List<IError>();
            errors = errors.Concat(companyEmailResult.Errors)
                .Concat(telephoneNumberResult.Errors)
                .Concat(companyAddressResult.Errors);

            return Result.Fail(errors);
        }

        ISet<TelephoneNumber> companyTelephoneNumbers = new HashSet<TelephoneNumber>(telephoneNumberResult.Value);

        Company existingCompany = _companies.GetCompanyByCompanyCode(companyData.CompanyCode);
        if (existingCompany != null)
        {
            return Result.Fail("A company with the same company code already exists.");
        }

        existingCompany = _companies.GetCompanyByName(companyData.Name);
        if (existingCompany != null)
        {
            return Result.Fail("A company with the same name already exists.");
        }

        existingCompany = _companies.GetCompanyByISIN(companyData.ISIN);
        if (existingCompany != null)
        {
            return Result.Fail("A company with the same ISIN already exists.");
        }

        Result<Company> companyResult = Company.Create(companyData.CompanyCode, companyData.Name, companyData.ISIN, companyAddressResult.Value, companyEmailResult.Value, companyTelephoneNumbers);

        if (companyResult.IsSuccess)
        {
            Company company = companyResult.Value;
            company.DateCreated = DateTime.Now;
            await _companies.AddAsync(company);
            await _unitOfWork.SaveChangesAsync();
            return Result.Ok(_mapper.Map<CompanyDto>(companyResult.Value));
        }

        return Result.Fail(companyResult.Errors);
    }
}
