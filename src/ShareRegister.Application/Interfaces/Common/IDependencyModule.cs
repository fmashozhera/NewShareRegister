using Microsoft.Extensions.DependencyInjection;

namespace ShareRegister.Application.Interfaces.Common;

public interface IDependencyModule
{    
    void RegisterDependecies(IServiceCollection services);   
}
