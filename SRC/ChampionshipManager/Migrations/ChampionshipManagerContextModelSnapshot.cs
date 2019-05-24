﻿// <auto-generated />
using ChampionshipManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChampionshipManager.Migrations
{
    [DbContext(typeof(ChampionshipManagerContext))]
    partial class ChampionshipManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("ChampionshipManager.Model.Championship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Championship");
                });

            modelBuilder.Entity("ChampionshipManager.Model.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("ChampionshipManager.Model.TeamChampionship", b =>
                {
                    b.Property<int>("ChampionshipId");

                    b.Property<int>("TeamId");

                    b.Property<int>("Id");

                    b.Property<int>("Level");

                    b.Property<int>("TreePosition");

                    b.HasKey("ChampionshipId", "TeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("Team_Championship");
                });

            modelBuilder.Entity("ChampionshipManager.Model.TeamChampionship", b =>
                {
                    b.HasOne("ChampionshipManager.Model.Championship", "Championship")
                        .WithMany("TeamsChampionship")
                        .HasForeignKey("ChampionshipId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChampionshipManager.Model.Team", "Team")
                        .WithMany("TeamChampionships")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
