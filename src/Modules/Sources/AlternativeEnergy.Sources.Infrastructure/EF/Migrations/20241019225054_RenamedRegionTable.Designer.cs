﻿// <auto-generated />
using System;
using AlternativeEnergy.Sources.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlternativeEnergy.Sources.Infrastructure.EF.Migrations
{
    [DbContext(typeof(SourcesModuleContext))]
    [Migration("20241019225054_RenamedRegionTable")]
    partial class RenamedRegionTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("sources")
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlternativeEnergy.Sources.Domain.Entities.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Regions", "sources");
                });

            modelBuilder.Entity("AlternativeEnergy.Sources.Domain.Entities.Source", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("CO2Emissions")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnergyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sources", "sources");
                });

            modelBuilder.Entity("AlternativeEnergy.Sources.Domain.Entities.UserEnergyChoice", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Consumption")
                        .HasColumnType("real");

                    b.Property<DateTime>("ConsumptionDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("SourceId");

                    b.ToTable("UserEnergyChoices", "sources");
                });

            modelBuilder.Entity("AlternativeEnergy.Sources.Domain.Entities.UserEnergyChoice", b =>
                {
                    b.HasOne("AlternativeEnergy.Sources.Domain.Entities.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlternativeEnergy.Sources.Domain.Entities.Source", "Source")
                        .WithMany("EnergyChoices")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("AlternativeEnergy.Sources.Domain.Entities.Source", b =>
                {
                    b.Navigation("EnergyChoices");
                });
#pragma warning restore 612, 618
        }
    }
}
