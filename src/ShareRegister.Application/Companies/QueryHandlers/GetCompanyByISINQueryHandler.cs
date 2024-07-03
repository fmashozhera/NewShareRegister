using AutoMapper;
using FluentResults;
using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Application.Companies.Queries;
using ShareRegister.Application.Interfaces.Common;
using ShareRegister.Domain.Common;

namespace ShareRegister.Application.Companies.QueryHandlers;
public class GetCompanyByISINQueryHandler : ICommandHandler<GetCompanyByISINQuery, CompanyDto>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public GetCompanyByISINQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }

    public Task<Result<CompanyDto>> Handle(GetCompanyByISINQuery request, CancellationToken cancellationToken)
    {
        Company company = _companyRepository.GetCompanyByISIN(request.ISIN);
        CompanyDto companyDto = _mapper.Map<CompanyDto>(company);
        return Task.FromResult(Result.Ok(companyDto));
    }
}
