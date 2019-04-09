using DemoScopedDI;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[assembly: WebJobsStartup(typeof(FunctionStartup))]
namespace DemoScopedDI
{   
    public class FunctionStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.AddLogging(logging =>
            {
                logging.AddFilter(level => true);
                logging.AddConsole();
            });
            builder.Services.AddScoped<ScopedDependency>();          
            builder.Services.AddMediatR();
        }
    }
}