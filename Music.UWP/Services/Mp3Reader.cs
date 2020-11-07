using Music.Model;
using Music.Model.Data;
using Music.Model.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagLib;
using File = TagLib.File;

namespace Music.UWP.Services
{
    public class Mp3Reader
    {
        private ModelContext db;

        public Mp3Reader()
        {
            db = new ModelContext();
        }

        private readonly string fileLocation = "Test/";
        public void ReadFile()
        {
            string[] files = Directory.GetFiles(this.fileLocation);
            foreach (string fileName in files) {
                Track track = GetTrack(fileName);
                File file = File.Create(fileName);
                if (file.Tag.Pictures.Length > 0)
                {
                    IPicture picture = file.Tag.Pictures[0];
                }
                if (track.Id <= 0 && file.MimeType == "taglib/mp3")
                {
                    Artist discArtist = ArtistRepository.GetArtistByName(file.Tag.FirstAlbumArtist);
                    Artist trackArtist = ArtistRepository.GetArtistByName(file.Tag.FirstPerformer);
                    track.Name = file.Tag.Title;
                    if (track.Name == "") { track.Name = "Unknown title"; }
                    track.Number = (int)file.Tag.Track;
                    if (track.Number < 1) { track.Number = 0; }
                    track.Disc = GetDiscWithAlbum(file.Tag.Album, (int)file.Tag.Disc, discArtist, (int)file.Tag.Year);
                    track.Genre = GenreRepository.GetGenreByName(file.Tag.FirstGenre);

                    db.Tracks.Add(track);
                    SaveChanges();

                    Contribution contribution = new Contribution
                    {
                        Track = track,
                        Artist = trackArtist,
                        ContributionType = MainContributionType()
                    };
                    db.Contributions.Add(contribution);
                    SaveChanges();
                }
            }
        }

        private readonly string[] excludedArtists = new string[]
        {
            "d-block & s-te-fan",
            "prefix & density"
        };

        private List<Artist> GetArtists(string completeName) {
            List<Artist> artists = new List<Artist>();
            char[] delimiterStrings = { '&' };
            string[] artistNames = completeName.Split(delimiterStrings);
            foreach(string artistName in artistNames)
            {
                artists.Add(new Artist { Name = artistName.Trim() });

            }
            return new List<Artist>();
        }


		private ContributionType MainContributionType()
		{
			string mainType = "Mainartist";
			ContributionType contribution = db.ContributionTypes.FirstOrDefault(c => c.Type == mainType);
			if (contribution == null)
			{
				contribution = new ContributionType
				{
					Type = mainType,
				};
				db.ContributionTypes.Add(contribution);
				SaveChanges();
			}
			return contribution;
		}

		private Disc GetDiscWithAlbum(string albumName, int discNumber, Artist discArtist, int releaseYear)
		{
			Album album = db.Albums.FirstOrDefault(a => a.Name == albumName);
			if (album == null)
			{
				album = new Album
				{
					Name = albumName,
					ReleaseYear = releaseYear,
				};
				db.Albums.Add(album);
				SaveChanges();
			}
			Disc disc = db.Discs.FirstOrDefault(d => d.Number == discNumber && d.AlbumId == album.Id);
			if (disc == null)
			{
				disc = new Disc
				{
					Album = album,
					Number = discNumber,
				};
				db.Discs.Add(disc);
                SaveChanges();

                DiscContribution discContribution = new DiscContribution
                {
                    Artist = discArtist,
                    Disc = disc,
                };
                db.DiscContributions.Add(discContribution);
                SaveChanges();
            }
			return disc;
		}

		private Track GetTrack(string fileName)
		{
			Track foundTrack = db.Tracks.FirstOrDefault(t => t.FileName == fileName);
			if (foundTrack != null)
			{
				return foundTrack;
			}
			Track track = new Track { FileName = fileName };
			return track;
		}

		private void SaveChanges()
		{
			db.SaveChanges();
		}
	}
}
