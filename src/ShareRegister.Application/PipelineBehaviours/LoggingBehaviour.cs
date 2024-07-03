using MediatR;
using Serilog;

namespace ShareRegister.Application.PipelineBehaviours;
public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>  
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Log.Information("Handling {@CommandType} with data {@RequestData}", typeof(TRequest).Name, request);
        var result = await next();        
        Log.Information("{@CommandType} handled successfully. Response : {@ResponseData}", typeof(TRequest).Name,result);        
        return result;      
    }
}
   
