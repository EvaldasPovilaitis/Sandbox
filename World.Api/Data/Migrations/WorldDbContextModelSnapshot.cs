﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using World.Api.Data;

namespace World.Api.Migrations
{
    [DbContext(typeof(WorldDbContext))]
    partial class WorldDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("World.Data.Entities.Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Continents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Africa"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Antarctica"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Asia"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Australia"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Europe"
                        },
                        new
                        {
                            Id = 6,
                            Name = "North America"
                        },
                        new
                        {
                            Id = 7,
                            Name = "South America"
                        });
                });

            modelBuilder.Entity("World.Data.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContinentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            ContinentId = 1,
                            Name = "South Africa"
                        },
                        new
                        {
                            Id = 102,
                            ContinentId = 1,
                            Name = "Nigeria"
                        },
                        new
                        {
                            Id = 103,
                            ContinentId = 1,
                            Name = "Kenya"
                        },
                        new
                        {
                            Id = 301,
                            ContinentId = 3,
                            Name = "China"
                        },
                        new
                        {
                            Id = 302,
                            ContinentId = 3,
                            Name = "India"
                        },
                        new
                        {
                            Id = 303,
                            ContinentId = 3,
                            Name = "Japan"
                        },
                        new
                        {
                            Id = 304,
                            ContinentId = 3,
                            Name = "Indonesia"
                        },
                        new
                        {
                            Id = 401,
                            ContinentId = 4,
                            Name = "Australia"
                        },
                        new
                        {
                            Id = 501,
                            ContinentId = 5,
                            Name = "Estonia"
                        },
                        new
                        {
                            Id = 502,
                            ContinentId = 5,
                            Name = "Latvia"
                        },
                        new
                        {
                            Id = 503,
                            ContinentId = 5,
                            Name = "Lithuania"
                        },
                        new
                        {
                            Id = 601,
                            ContinentId = 6,
                            Name = "United States"
                        },
                        new
                        {
                            Id = 602,
                            ContinentId = 6,
                            Name = "Canada"
                        },
                        new
                        {
                            Id = 603,
                            ContinentId = 6,
                            Name = "Mexico"
                        },
                        new
                        {
                            Id = 701,
                            ContinentId = 7,
                            Name = "Brazil"
                        },
                        new
                        {
                            Id = 702,
                            ContinentId = 7,
                            Name = "Chile"
                        },
                        new
                        {
                            Id = 703,
                            ContinentId = 7,
                            Name = "Argentina"
                        },
                        new
                        {
                            Id = 704,
                            ContinentId = 7,
                            Name = "Columbia"
                        });
                });

            modelBuilder.Entity("World.Data.Entities.CountryType", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("CountryId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("CountryTypes");

                    b.HasData(
                        new
                        {
                            CountryId = 101,
                            TypeId = 1
                        },
                        new
                        {
                            CountryId = 101,
                            TypeId = 2
                        },
                        new
                        {
                            CountryId = 101,
                            TypeId = 3
                        },
                        new
                        {
                            CountryId = 102,
                            TypeId = 1
                        },
                        new
                        {
                            CountryId = 103,
                            TypeId = 2
                        },
                        new
                        {
                            CountryId = 301,
                            TypeId = 3
                        },
                        new
                        {
                            CountryId = 302,
                            TypeId = 1
                        },
                        new
                        {
                            CountryId = 303,
                            TypeId = 2
                        });
                });

            modelBuilder.Entity("World.Data.Entities.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "One of eight"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Third world country"
                        },
                        new
                        {
                            Id = 3,
                            Name = "One of EU"
                        });
                });

            modelBuilder.Entity("World.Data.Entities.Country", b =>
                {
                    b.HasOne("World.Data.Entities.Continent", "Continent")
                        .WithMany("Countries")
                        .HasForeignKey("ContinentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("World.Data.Entities.CountryType", b =>
                {
                    b.HasOne("World.Data.Entities.Country", "Country")
                        .WithMany("CountryTypes")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("World.Data.Entities.Type", "Type")
                        .WithMany("CountryTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
