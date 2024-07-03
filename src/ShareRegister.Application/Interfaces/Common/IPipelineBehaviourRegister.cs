using Microsoft.Extensions.DependencyInjection;

namespace ShareRegister.Application.Interfaces.Common;
public interface IPipelineBehaviourRegister
{
    void RegisterBehaviours(MediatRServiceConfiguration configuration);
}
