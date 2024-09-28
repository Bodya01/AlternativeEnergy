﻿using AlternativeEnergy.Domain.Entities;

namespace AlternativeEnergy.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<Guid> AddAsync(User user, CancellationToken cancellationToken = default);
        Task UpdateAsync(User user, CancellationToken cancellationToken = default);
    }
}
