using BasMa.Api.Template.Core.Application.PipelineBehavior;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BasMa.Api.Template.Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services.AddMediatR(Assembly.GetExecutingAssembly())
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        public static IMvcBuilder AddValidation(this IMvcBuilder mvcBuilder) =>
            mvcBuilder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
