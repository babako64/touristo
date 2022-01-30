﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace FlightService.Application.Common.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        //private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour()
        {
           
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
             //   _logger.LogError(ex, "Application Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
}
