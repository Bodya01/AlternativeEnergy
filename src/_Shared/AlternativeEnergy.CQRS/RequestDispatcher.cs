using AlternativeEnergy.CQRS.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.CQRS
{
    internal sealed class RequestDispatcher : ISender
    {
        private readonly IServiceProvider _serviceProvider;

        public RequestDispatcher(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task PublishAsync<T>(T request, CancellationToken cancellationToken = default) where T : IRequest
        {
            using var scope = _serviceProvider.CreateScope();

            var handlers = scope.ServiceProvider.GetServices<IRequestHandler<T>>();

            foreach (var handler in handlers) await handler.Handle(request, cancellationToken);
        }

        public async Task<TResponse> PublishAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>
        {
            using var scope = _serviceProvider.CreateScope();

            var handler = scope.ServiceProvider.GetService<IRequestHandler<TRequest, TResponse>>();

            if (handler is null) throw new HandlerNotRegisteredException($"Handler for type: {typeof(TRequest).Name} is not registered.");

            TResponse result = await handler.Handle(request, cancellationToken);

            return result;
        }
    }
}
