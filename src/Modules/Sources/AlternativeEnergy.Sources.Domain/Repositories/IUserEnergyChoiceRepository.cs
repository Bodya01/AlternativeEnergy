using AlternativeEnergy.DDD.Repositories;
using AlternativeEnergy.Sources.Domain.Entities;

namespace AlternativeEnergy.Sources.Domain.Repositories
{
    public interface IUserEnergyChoiceRepository : IRepositoryBase<UserEnergyChoice, Guid>
    {
    }
}
