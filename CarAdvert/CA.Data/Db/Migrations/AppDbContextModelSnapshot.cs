using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CA.Data.Db;

namespace CA.Data.Db.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CA.Data.Entities.CarAdvert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("FirstRegistration");

                    b.Property<int>("FuelTypeId");

                    b.Property<int>("Mileage");

                    b.Property<bool>("New");

                    b.Property<int>("Price");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FuelTypeId");

                    b.ToTable("Adverts");
                });

            modelBuilder.Entity("CA.Data.Entities.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(24);

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("CA.Data.Entities.CarAdvert", b =>
                {
                    b.HasOne("CA.Data.Entities.FuelType", "Fuel")
                        .WithMany("Adverts")
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
