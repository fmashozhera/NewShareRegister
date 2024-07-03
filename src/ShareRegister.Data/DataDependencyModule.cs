using Microsoft.Extensions.DependencyInjection;
using ShareRegister.Application.Companies.Queries;
using ShareRegister.Application.Interfaces.Common;
using ShareRegister.Data.Common;
using ShareRegister.Data.Repositories;
using ShareRegister.Domain.Common;
using ShareRegister.Domain.Common.Interfaces;

namespace ShareRegister.Data;
public class DataDependencyModule : IDependencyModule
{
    public void RegisterDependecies(IServiceCollection services)
    {
        services.AddScoped<ApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWOrk>();
        services.AddScoped<IRepository<Address>, Repository<Address>>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
    }
}
