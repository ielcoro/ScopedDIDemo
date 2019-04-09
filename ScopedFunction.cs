using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MediatR;
using DemoScopedDI.Actions;

namespace DemoScopedDI
{
    public class ScopedFunction
    {
        private readonly IMediator mediator;

        public ScopedFunction(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [FunctionName("ScopedFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            var dependency = await mediator.Send(new CallScopedDependency());

            //This should always return Runs 1 and a differente instance hash
            return new OkObjectResult(dependency);
        }            
    }
}
