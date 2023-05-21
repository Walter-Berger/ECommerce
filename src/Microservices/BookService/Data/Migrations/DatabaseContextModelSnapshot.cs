﻿// <auto-generated />
using System;
using BookService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookService.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookService.Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CreationTimestampUnix")
                        .HasColumnType("bigint");

                    b.Property<long>("EditedTimestampUnix")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsBought")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLoaned")
                        .HasColumnType("boolean");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("books", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
