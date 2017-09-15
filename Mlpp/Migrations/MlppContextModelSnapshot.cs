﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Mlpp.Infrastructure.Storage.Mlpp;
using System;

namespace Mlpp.Migrations
{
    [DbContext(typeof(MlppContext))]
    partial class MlppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mlpp.Domain.Product.States.PartState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid?>("ProductStateId");

                    b.HasKey("Id");

                    b.HasIndex("ProductStateId");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("Mlpp.Domain.Product.States.ProductState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<bool>("Removed");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Mlpp.Domain.Product.States.PartState", b =>
                {
                    b.HasOne("Mlpp.Domain.Product.States.ProductState")
                        .WithMany("Parts")
                        .HasForeignKey("ProductStateId");
                });
#pragma warning restore 612, 618
        }
    }
}
