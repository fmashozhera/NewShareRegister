using AutoMapper;
using FluentResults;
using ShareRegister.Application.Companies.Commands;
using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Application.Companies.Queries;
using ShareRegister.Application.Interfaces.Common;
using ShareRegister.Domain.Common;

namespace ShareRegister.Application.Companies.CommandHandlers;
public class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyCommand, CompanyDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICompanyRepository _companyRepository;

    public UpdateCompanyCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICompanyRepository companyRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _companyRepository = companyRepository;
    }

    public async Task<Result<CompanyDto>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        Company currentCompany = _companyRepository.GetById(request.Company.Id); 
        Company updatedCompany = _mapper.Map<Company>(request.Company);
        var companyUpdateResult = currentCompany.Update(updatedCompany.CompanyCode,updatedCompany.Name,updatedCompany.ISIN,updatedCompany.Address,updatedCompany.Email,updatedCompany.TelephoneNumbers);
        await _unitOfWork.SaveChangesAsync();
        
        if (companyUpdateResult.IsSuccess)
        {
            CompanyDto companyDto = _mapper.Map<CompanyDto>(companyUpdateResult.Value);
            return Result.Ok(companyDto);
        }
        else
        {
            return Result.Fail(companyUpdateResult.Errors);           
        }
    }
}
