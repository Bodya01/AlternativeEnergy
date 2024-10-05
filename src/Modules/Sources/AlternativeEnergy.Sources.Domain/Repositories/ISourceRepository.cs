using AlternativeEnergy.DDD.Repositories;
using AlternativeEnergy.Sources.Domain.Entities;

namespace AlternativeEnergy.Sources.Domain.Repositories
{
    public interface ISourceRepository : IRepositoryBase<Source, Guid>
    {
    }
}
