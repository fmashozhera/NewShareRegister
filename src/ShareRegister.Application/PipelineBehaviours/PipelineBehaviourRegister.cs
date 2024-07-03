using FluentResults;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShareRegister.Application.Companies.Commands;
using ShareRegister.Application.Companies.Dtos;
using ShareRegister.Application.Interfaces.Common;

namespace ShareRegister.Application.PipelineBehaviours;
public class PipelineBehaviourRegister : IPipelineBehaviourRegister
{
    public void RegisterBehaviours(MediatRServiceConfiguration configuration)
    {
        configuration.AddBehavior<IPipelineBehavior<CreateCompanyCommand, Result<CompanyDto>>, LoggingBehaviour<CreateCompanyCommand, Result<CompanyDto>>>();
    }
}
