﻿// <auto-generated />
using System;
using FinanceManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinanceManager.Infrastructure.Migrations
{
    [DbContext(typeof(FinanceManagerDbContext))]
    partial class FinanceManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FinanceManager.Domain.AccountAggregate.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Accounts", (string)null);
                });

            modelBuilder.Entity("FinanceManager.Domain.AccountAggregate.Account", b =>
                {
                    b.OwnsMany("FinanceManager.Domain.MovementAggregate.ValueObjects.MovementId", "Movements", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("AccountId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("MovementId");

                            b1.HasKey("Id");

                            b1.HasIndex("AccountId");

                            b1.ToTable("AccountMovementIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.OwnsMany("FinanceManager.Domain.UserAggregate.ValueObjects.UserId", "Users", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("AccountId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Value")
                                .HasColumnType("char(36)")
                                .HasColumnName("UserId");

                            b1.HasKey("Id");

                            b1.HasIndex("AccountId");

                            b1.ToTable("AccountUserIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("AccountId");
                        });

                    b.Navigation("Movements");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}