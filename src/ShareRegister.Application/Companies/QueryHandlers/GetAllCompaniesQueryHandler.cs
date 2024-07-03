using AutoMapper;
using FluentResults;
using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Application.Companies.Queries;
using ShareRegister.Application.Interfaces.Common;
using ShareRegister.Domain.Common;

namespace ShareRegister.Application.Companies.QueryHandlers;
public class GetAllCompaniesQueryHandler : ICommandHandler<GetAllCompaniesQuery, List<CompanyDto>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }

    public Task<Result<List<CompanyDto>>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        List<Company> companies = _companyRepository.GetAllCompanies(request.Skip,request.Take);
        List<CompanyDto> result = _mapper.Map<List<CompanyDto>>(companies);
        return Task.FromResult(Result.Ok(result));
    }
}
