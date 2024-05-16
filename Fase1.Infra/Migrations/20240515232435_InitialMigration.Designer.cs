﻿// <auto-generated />
using Fase1.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fase1.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240515232435_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fase1.Core.Entities.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(300)");

                    b.Property<int>("RegiaoId")
                        .HasColumnType("INT");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(300)");

                    b.HasKey("Id");

                    b.HasIndex("RegiaoId");

                    b.ToTable("Contato", (string)null);
                });

            modelBuilder.Entity("Fase1.Core.Entities.Regiao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasColumnType("VARCHAR(3)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(300)");

                    b.HasKey("Id");

                    b.ToTable("Regiao", (string)null);
                });

            modelBuilder.Entity("Fase1.Core.Entities.Contato", b =>
                {
                    b.HasOne("Fase1.Core.Entities.Regiao", "Regiao")
                        .WithMany("Contatos")
                        .HasForeignKey("RegiaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Regiao");
                });

            modelBuilder.Entity("Fase1.Core.Entities.Regiao", b =>
                {
                    b.Navigation("Contatos");
                });
#pragma warning restore 612, 618
        }
    }
}