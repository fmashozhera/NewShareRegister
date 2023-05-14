using FluentResults;
using ShareRegister.Application.Companies.Commands;
using ShareRegister.Application.Interfaces.Common;
using ShareRegister.Domain.Common;

namespace ShareRegister.Application.Companies.CommandHandlers;

public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand>
{
    private readonly IRepository<Company> _companies;
    private readonly IRepository<Address> _addresses;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCompanyCommandHandler(IRepository<Company> companies, IUnitOfWork unitOfWork, IRepository<Address> addresses)
    {
        _companies = companies;
        _unitOfWork = unitOfWork;
        _addresses = addresses;
    }

    public async Task<Result> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var addressResult = Address.Create(request.Street,request.Surburb,request.City,request.Country,request.ZipCode);
        if(addressResult.IsSuccess)
        {
            await _addresses.AddAsync(addressResult.Value);
            await _unitOfWork.SaveChangesAsync();
            return Result.Ok();
        }
        return Result.Fail(addressResult.Errors);
    }
}
