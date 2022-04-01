using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ProEventos.Application.Dependencies
{
    public static class HandlerDependencies
    {
        public static IServiceCollection RegisterRequestHandlers(
        this IServiceCollection services)
        {
            return services
                .AddMediatR(typeof(HandlerDependencies).Assembly);
        }
    }
}