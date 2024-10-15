using AlternativeEnergy.Messaging;
using AlternativeEnergy.Sources.Application.Events;
using AlternativeEnergy.Sources.Domain.Entities;
using AlternativeEnergy.Sources.Domain.Repositories;
using MediatR;

namespace AlternativeEnergy.Sources.Application.Commands.Handlers
{
    internal sealed class CreateSourceHandler : IRequestHandler<CreateSource, Guid>
    {
        private readonly ISourceRepository _sourceRepository;
        private readonly IInMemoryMessageBus _messageBus;

        public CreateSourceHandler(ISourceRepository sourceRepository, IInMemoryMessageBus messageBus)
            => (_sourceRepository, _messageBus) = (sourceRepository, messageBus);

        public async Task<Guid> Handle(CreateSource request, CancellationToken cancellationToken)
        {
            var source = Source.Create(Guid.NewGuid(), request.Name, request.Decription, request.EnergyType, request.CO2Emissions);

            await _sourceRepository.CreateAsync(source, cancellationToken);
            await _sourceRepository.SaveChangesAsync(cancellationToken);

            await _messageBus.PublishAsync(new SourceCreatedEvent(source.Id, source.Name, source.EnergyType.ToString(), source.CO2Emissions));

            return source.Id;
        }
    }
}
