using FluentResults;
using MediatR;

namespace ShareRegister.Application.Interfaces.Common;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
