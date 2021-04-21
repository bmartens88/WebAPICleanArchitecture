using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BasMa.Api.Template.Core.Application.Features.Hello.Queries
{
    public class GetGreetingQuery : IRequest<string>
    {
        public string Name { get; set; }

        public class GetGreetingHandler : IRequestHandler<GetGreetingQuery, string>
        {
            public Task<string> Handle(GetGreetingQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult($"Hello, {request.Name}!");
            }
        }
    }
}
