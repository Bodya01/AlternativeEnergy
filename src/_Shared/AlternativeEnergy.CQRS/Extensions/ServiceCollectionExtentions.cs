using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AlternativeEnergy.CQRS.Extensions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddCQRS(this IServiceCollection services)
            => services.AddScoped<ISender, RequestDispatcher>();

        public static IServiceCollection AddCQRSHandlersFromAssembly(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();


            var resultedTypes = assembly
                .GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && type.GetInterfaces().Any(IsRequestHandlerInterface))
                .ToList();

            foreach (var type in resultedTypes)
            {
                var handlerInterface = type.GetInterfaces()
                    .Where(i =>
                        i.IsGenericType &&
                        (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) || i.GetGenericTypeDefinition() == typeof(IRequestHandler<>))
                    )
                    .FirstOrDefault();

                services.AddTransient(handlerInterface!, type);
            }

            return services;

            bool IsRequestHandlerInterface(Type interfaceType) =>
                interfaceType.IsGenericType && (
                    interfaceType.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                    interfaceType.GetGenericTypeDefinition() == typeof(IRequestHandler<>)
                );
        }
    }
}

