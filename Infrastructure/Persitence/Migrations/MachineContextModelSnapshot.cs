﻿// <auto-generated />
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persitence.Migrations
{
    [DbContext(typeof(MachineContext))]
    partial class MachineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.SnackSequence", "'SnackSequence', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:HiLoSequenceName", "SnackSequence")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

            modelBuilder.Entity("Domain.SnackMachine.SnackMachine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.HasKey("Id");

                    b.ToTable("SnackMachines");
                });

            modelBuilder.Entity("Domain.SnackMachine.SnackMachine", b =>
                {
                    b.OwnsOne("Domain.SnackMachine.Money", "MoneyInside", b1 =>
                        {
                            b1.Property<long>("SnackMachineId")
                                .HasColumnType("bigint");

                            b1.Property<int>("FiveDollarCount")
                                .HasColumnType("int");

                            b1.Property<int>("OneCentCount")
                                .HasColumnType("int");

                            b1.Property<int>("OneDollarCount")
                                .HasColumnType("int");

                            b1.Property<int>("QuarterCount")
                                .HasColumnType("int");

                            b1.Property<int>("TenCentCount")
                                .HasColumnType("int");

                            b1.Property<int>("TwentyDollarCount")
                                .HasColumnType("int");

                            b1.HasKey("SnackMachineId");

                            b1.ToTable("SnackMachines");

                            b1.WithOwner()
                                .HasForeignKey("SnackMachineId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}