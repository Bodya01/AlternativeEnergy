namespace AlternativeEnergy.CQRS
{
    public interface ISender
    {
        Task PublishAsync<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest;
        Task<TResponse> PublishAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>;
    }
}
