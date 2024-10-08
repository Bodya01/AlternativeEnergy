﻿using AlternativeEnergy.Identity.Domain.Entities;
using AlternativeEnergy.Identity.Infrastructure.EF.DbModels;
using AlternativeEnergy.Identity.Infrastructure.EF.Maps;
using AlternativeEnergy.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlternativeEnergy.Identity.Infrastructure.EF.Context
{
    internal sealed class IdentityModuleContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public IdentityModuleContext(DbContextOptions<IdentityModuleContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(DbSchemas.Identity);
            builder.ApplyConfiguration(new RefreshTokenMap());

            base.OnModelCreating(builder);
        }
    }
}