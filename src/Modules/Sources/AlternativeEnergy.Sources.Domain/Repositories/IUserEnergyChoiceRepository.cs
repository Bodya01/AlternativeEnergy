using AlternativeEnergy.Abstractions.Repository;
using AlternativeEnergy.Sources.Domain.Entities;

namespace AlternativeEnergy.Sources.Domain.Repositories
{
    public interface IUserEnergyChoiceRepository : IRepositoryBase<UserEnergyChoice, Guid>
    {
    }
}
