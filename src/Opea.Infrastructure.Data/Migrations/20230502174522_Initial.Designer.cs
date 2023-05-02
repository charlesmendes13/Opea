﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Opea.Infrastructure.Data.Context;

#nullable disable

namespace Opea.Infrastructure.Data.Migrations
{
    [DbContext(typeof(OpeaContext))]
    [Migration("20230502174522_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Opea.Domain.AggregatesModel.ClientAggregate.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("_companySizeId")
                        .HasColumnType("int")
                        .HasColumnName("CompanySize");

                    b.HasKey("Id");

                    b.HasIndex("_companySizeId");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("Opea.Domain.AggregatesModel.ClientAggregate.CompanySize", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("CompanySize", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Small"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Large"
                        });
                });

            modelBuilder.Entity("Opea.Domain.AggregatesModel.ClientAggregate.Client", b =>
                {
                    b.HasOne("Opea.Domain.AggregatesModel.ClientAggregate.CompanySize", "CompanySize")
                        .WithMany()
                        .HasForeignKey("_companySizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanySize");
                });
#pragma warning restore 612, 618
        }
    }
}