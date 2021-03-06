﻿// <auto-generated />
using EfCore5Test.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCore5Test.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EfCore5Test.Db.FirstModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("Firsts");
                });

            modelBuilder.Entity("EfCore5Test.Db.MyCoolModel", b =>
                {
                    b.Property<int>("FirstId")
                        .HasColumnType("int");

                    b.Property<int>("SecondId")
                        .HasColumnType("int");

                    b.Property<string>("SomeText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FirstId", "SecondId");

                    b.HasIndex("SecondId");

                    b.ToTable("MyCoolModels");
                });

            modelBuilder.Entity("EfCore5Test.Db.SecondModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("Seconds");
                });

            modelBuilder.Entity("EfCore5Test.Db.MyCoolModel", b =>
                {
                    b.HasOne("EfCore5Test.Db.FirstModel", "First")
                        .WithMany()
                        .HasForeignKey("FirstId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCore5Test.Db.SecondModel", "Second")
                        .WithMany()
                        .HasForeignKey("SecondId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("First");

                    b.Navigation("Second");
                });
#pragma warning restore 612, 618
        }
    }
}
