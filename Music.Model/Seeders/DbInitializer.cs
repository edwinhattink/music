using Music.Model.Data;
using System;
using System.Linq;

namespace Music.Model.Seeders
{
    public static class DbInitializer
    {
        public static void Initialize(ModelContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Albums.Any())
            {
                return;   // DB has been seeded
            }

            var mainArtist = new ContributionType { Type = "Main" };
            var featuring = new ContributionType { Type = "Featuring" };
            var remix = new ContributionType { Type = "Remix" };

            context.ContributionTypes.Add(mainArtist);
            context.ContributionTypes.Add(featuring);
            context.ContributionTypes.Add(remix);

            context.SaveChanges();

            var albums = new Album[]
            {
                new Album{Name="The First Dose",ReleaseYear=2020},
            };
            foreach (Album a in albums)
            {
                context.Albums.Add(a);
            }
            context.SaveChanges();

            var artists = new Artist[]
            {
                new Artist{Name="Rebelion"},
                new Artist{Name="Radical Redemption"},
            };
            foreach (Artist a in artists)
            {
                context.Artists.Add(a);
            }
            context.SaveChanges();

            var hardstyle = new Genre { Name = "Hardstyle" };
            context.Genres.Add(hardstyle);
            context.SaveChanges();

            var rawHardstyle = new Genre { Name = "Raw Hardstyle", ParentGenreId = 1 };
            var euphoricHardstyle = new Genre { Name = "Euphoric Hardstyle", ParentGenreId = 1 };
            context.Genres.Add(rawHardstyle);
            context.Genres.Add(euphoricHardstyle);
            context.SaveChanges();

            context.Discs.Add(new Disc { AlbumId = 1, Number = 1 });
            context.SaveChanges();

            context.DiscContributions.Add(new DiscContribution { ArtistId = 1, DiscId = 1 });
            context.SaveChanges();

            context.Tracks.Add(new Track { DiscId = 1, GenreId = 2, Name = "Hardest Baddest Motherfucker", Number = 2 });
            context.Tracks.Add(new Track { DiscId = 1, GenreId = 2, Name = "Modulate", Number = 6 });
            context.Tracks.Add(new Track { DiscId = 1, GenreId = 2, Name = "Sydiket", Number = 7 });
            context.Tracks.Add(new Track { DiscId = 1, GenreId = 2, Name = "This Is Not A Test", Number = 8 });
            context.SaveChanges();

            context.Contributions.Add(new Contribution { ContributionTypeId = 1, ArtistId = 1, TrackId = 1 });
            context.Contributions.Add(new Contribution { ContributionTypeId = 1, ArtistId = 1, TrackId = 2 });
            context.Contributions.Add(new Contribution { ContributionTypeId = 1, ArtistId = 1, TrackId = 3 });
            context.Contributions.Add(new Contribution { ContributionTypeId = 1, ArtistId = 1, TrackId = 4 });
            context.SaveChanges();

        }
    }
}