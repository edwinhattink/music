﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Music.Model.Data;

namespace Music.Model.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20181223131359_InitialSetup")]
    partial class InitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Music.Model.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<int>("ReleaseYear");

                    b.HasKey("Id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Music.Model.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Music.Model.Contribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArtistId");

                    b.Property<int>("ContributionTypeId");

                    b.Property<int>("TrackId");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("ContributionTypeId");

                    b.HasIndex("TrackId");

                    b.ToTable("Contributions");
                });

            modelBuilder.Entity("Music.Model.ContributionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("ContributionTypes");
                });

            modelBuilder.Entity("Music.Model.Disc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlbumId");

                    b.Property<int>("ArtistId");

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Discs");
                });

            modelBuilder.Entity("Music.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Music.Model.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DiscId");

                    b.Property<string>("FileName");

                    b.Property<int>("GenreId");

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.HasIndex("DiscId");

                    b.HasIndex("GenreId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Music.Model.Contribution", b =>
                {
                    b.HasOne("Music.Model.Artist", "Artist")
                        .WithMany("Contributions")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Music.Model.ContributionType", "ContributionType")
                        .WithMany()
                        .HasForeignKey("ContributionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Music.Model.Track", "Track")
                        .WithMany("Contributions")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Music.Model.Disc", b =>
                {
                    b.HasOne("Music.Model.Album", "Album")
                        .WithMany("Discs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Music.Model.Artist", "Artist")
                        .WithMany("Discs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Music.Model.Track", b =>
                {
                    b.HasOne("Music.Model.Disc", "Disc")
                        .WithMany("Tracks")
                        .HasForeignKey("DiscId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Music.Model.Genre", "Genre")
                        .WithMany("Tracks")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
