using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Statements.Application.Common.Behaviors
{
    public class LogginBehavior<TRequest, TResponce> : IPipelineBehavior<TRequest, TResponce> where TRequest : IRequest<TResponce>
    {
        public async Task<TResponce> Handle(TRequest request, RequestHandlerDelegate<TResponce> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            Log.Information("Statements request: {Name} {@Request}", requestName, request);
            var responce = await next();
            return responce;
        }
    }
}
