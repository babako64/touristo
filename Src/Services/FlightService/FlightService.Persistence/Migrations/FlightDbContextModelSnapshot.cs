// <auto-generated />
using System;
using FlightService.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlightService.Persistence.Migrations
{
    [DbContext(typeof(FlightDbContext))]
    partial class FlightDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FlightService.Domain.Entities.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeatAvailable")
                        .HasColumnType("int");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightService.Domain.Entities.FlightSection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AirlineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("DestinationAirportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationCityCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("DestinationCityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FlightId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("FlightSectionDuration")
                        .HasColumnType("time");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("OriginAirportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginCityCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("OriginCityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("FlightSections");
                });

            modelBuilder.Entity("FlightService.Domain.Entities.FlightSection", b =>
                {
                    b.HasOne("FlightService.Domain.Entities.Flight", "Flight")
                        .WithMany("Sections")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("FlightService.Domain.Entities.Flight", b =>
                {
                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
