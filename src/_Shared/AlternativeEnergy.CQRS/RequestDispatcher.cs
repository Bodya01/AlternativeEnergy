using AlternativeEnergy.CQRS.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace AlternativeEnergy.CQRS
{
    internal sealed class RequestDispatcher : ISender
    {
        private readonly IServiceProvider _serviceProvider;

        public RequestDispatcher(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task SendAsync<T>(T request, CancellationToken cancellationToken = default) where T : IRequest
        {
            using var scope = _serviceProvider.CreateScope();

            var handlers = scope.ServiceProvider.GetServices<IRequestHandler<T>>();

            foreach (var handler in handlers) await handler.Handle(request, cancellationToken);
        }

        public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            using var scope = _serviceProvider.CreateScope();

            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

            var handler = _serviceProvider.GetService(handlerType);

            if (handler is null) throw new HandlerNotRegisteredException($"Handler for type: {request.GetType().Name} is not registered.");

            var handleMethod = handlerType.GetMethod("Handle");
            var resultTask = handleMethod!.Invoke(handler, [request, cancellationToken]) as Task<TResponse>;

            return await resultTask;
        }
    }
}
