using AutoMapper;
using FluentResults;
using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Application.Companies.Queries;
using ShareRegister.Application.Interfaces.Common;
using ShareRegister.Domain.Common;

namespace ShareRegister.Application.Companies.QueryHandlers;
public class GetCompanyByCompanyCodeQueryHandler : ICommandHandler<GetCompanyByCompanyCodeQuery, CompanyDto>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;

    public GetCompanyByCompanyCodeQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
    }
    public Task<Result<CompanyDto>> Handle(GetCompanyByCompanyCodeQuery request, CancellationToken cancellationToken)
    {
        Company company = _companyRepository.GetCompanyByCompanyCode(request.CompanyCode);
        var companyDto = _mapper.Map<CompanyDto>(company);
        return Task.FromResult(Result.Ok(companyDto));
    }
}
