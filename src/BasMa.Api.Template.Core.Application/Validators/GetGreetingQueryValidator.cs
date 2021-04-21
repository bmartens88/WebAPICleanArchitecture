using BasMa.Api.Template.Core.Application.Features.Hello.Queries;
using FluentValidation;

namespace BasMa.Api.Template.Core.Application.Validators
{
    public class GetGreetingQueryValidator : AbstractValidator<GetGreetingQuery>
    {
        public GetGreetingQueryValidator()
        {
            RuleFor(q => q.Name)
                .NotEmpty();
        }
    }
}
