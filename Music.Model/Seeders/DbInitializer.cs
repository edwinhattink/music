using Music.Model.Data;

namespace Music.Model.Seeders
{
    public static class DbInitializer
    {
        public static void Initialize(ModelContext context)
        {
            context.Database.EnsureCreated();


            string albumName = "The First Dose";
            // Look for any albums.
            var foundAlbums = context.Albums.Where(a => a.Name == albumName).ToList();
            if (foundAlbums.Any())
            {
                return;   // DB has been seeded
            }

            context.SaveChanges();

            var theFirstDose = new Album { Name = albumName, ReleaseYear = 2020 };
            var albums = new Album[]
            {
                theFirstDose,
            };
            foreach (Album a in albums)
            {
                context.Albums.Add(a);
            }
            context.SaveChanges();

            var rebelion = new Artist { Name = "Rebelion" };
            var artists = new Artist[]
            {
                rebelion,
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

            var rawHardstyle = new Genre { Name = "Raw Hardstyle", ParentGenre = hardstyle };
            var euphoricHardstyle = new Genre { Name = "Euphoric Hardstyle", ParentGenre = hardstyle };
            context.Genres.Add(rawHardstyle);
            context.Genres.Add(euphoricHardstyle);
            context.SaveChanges();

            var theFirstDoseDiscOne = new Disc { Album = theFirstDose, Number = 1, Name = "Disc One" };
            context.Discs.Add(theFirstDoseDiscOne);
            context.SaveChanges();

            context.DiscContributions.Add(new DiscContribution { Artist = rebelion, Disc = theFirstDoseDiscOne });
            context.SaveChanges();

            context.Tracks.Add(new Track { Disc = theFirstDoseDiscOne, Genre = rawHardstyle, Name = "Hardest Baddest Motherfucker", Number = 2 });
            context.Tracks.Add(new Track { Disc = theFirstDoseDiscOne, Genre = rawHardstyle, Name = "Modulate", Number = 6 });
            context.Tracks.Add(new Track { Disc = theFirstDoseDiscOne, Genre = rawHardstyle, Name = "Sydiket", Number = 7 });
            context.Tracks.Add(new Track { Disc = theFirstDoseDiscOne, Genre = rawHardstyle, Name = "This Is Not A Test", Number = 8 });
            context.SaveChanges();

            var tracks = context.Tracks.ToList();
            context.Contributions.Add(new Contribution { ContributionType = ContributionType.Main, Artist = rebelion, Track = tracks.ElementAt(0) });
            context.Contributions.Add(new Contribution { ContributionType = ContributionType.Main, Artist = rebelion, Track = tracks.ElementAt(1) });
            context.Contributions.Add(new Contribution { ContributionType = ContributionType.Main, Artist = rebelion, Track = tracks.ElementAt(2) });
            context.Contributions.Add(new Contribution { ContributionType = ContributionType.Main, Artist = rebelion, Track = tracks.ElementAt(3) });
            context.SaveChanges();

        }
    }
}