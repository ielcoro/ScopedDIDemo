using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace DemoScopedDI.Actions
{
    public class CallScopedDependencyHandler : IRequestHandler<CallScopedDependency, ScopedDependency>
    {
        private readonly ScopedDependency dependency;        

        public CallScopedDependencyHandler(ScopedDependency dependency) 
        {
            this.dependency = dependency;
        }

        public Task<ScopedDependency> Handle(CallScopedDependency request, CancellationToken cancellationToken)
        {
            dependency.Run();

            return Task.FromResult(dependency);
        }
    }
}