using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music.Model;
using Music.Model.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Music.Web.Controllers
{
    [Route("api/scan")]
    public class ScanController : Controller
    {
        private readonly ModelContext _context;

        public ScanController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<object>> Scan()
        {
            var mp3s = Directory.GetFiles("C:\\git\\Music\\Music.Web\\wwwroot\\Music", "*.mp3", SearchOption.AllDirectories);

            foreach (var mp3Path in mp3s)
            {
                var tfile = TagLib.File.Create(mp3Path);

                //TODO: async maken
                var genre = GetOrCreateGenre(tfile.Tag.JoinedGenres);
                var album = GetOrCreateAlbum(tfile.Tag.Album, checked((int)tfile.Tag.Year));
                var disc = GetOrCreateDisc(album.Id, checked((int)tfile.Tag.Disc));
                var track = GetOrCreateTrack(mp3Path, tfile.Tag.Title, checked((int) tfile.Tag.Track), genre.Id, disc.Id);
                var artist = GetOrCreateArtist(tfile.Tag.JoinedPerformers);
                GetOrCreateContribution(artist.Id, track.Id);
                var albumArtist = GetOrCreateArtist(tfile.Tag.JoinedAlbumArtists);
                
                

            }

            return mp3s;
        }

        private Contribution GetOrCreateContribution(int artistId, int trackId)
        {
            //TODO: betere performance van maken door NIET eerst alles op te halen (IQueryable<Contribution>)
            // IQueryable<Contribution> query = _context.Contributions;
            IEnumerable<Contribution> query = _context.Contributions.ToList();
            query = query.Where(c => c.ArtistId == artistId && c.TrackId == trackId);
            var contribution = query.FirstOrDefault(new Contribution() { 
                ArtistId = artistId,
                TrackId = trackId,
                ContributionType = ContributionType.Main
            });

            if (contribution.Id < 1)
            {
                _context.Contributions.Add(contribution);
                _context.SaveChanges();
            }

            return contribution;
        }

        private DiscContribution GetOrCreateDscContribution(int artistId, int discId)
        {
            //TODO: betere performance van maken door NIET eerst alles op te halen (IQueryable<DiscContribution>)
            // IQueryable<DiscContribution> query = _context.DiscContributions;
            IEnumerable<DiscContribution> query = _context.DiscContributions.ToList();
            query = query.Where(c => c.ArtistId == artistId && c.DiscId == discId);
            var contribution = query.FirstOrDefault(new DiscContribution()
            {
                ArtistId = artistId,
                DiscId = discId
            });

            if (contribution.Id < 1)
            {
                _context.DiscContributions.Add(contribution);
                _context.SaveChanges();
            }

            return contribution;
        }

        private Genre GetOrCreateGenre(string genreName)
        {
            //TODO: betere performance van maken door NIET eerst alles op te halen (IQueryable<Genre>)
            IEnumerable<Genre> query = _context.Genres.ToList();
            query = query.Where(g => g.Name == genreName);
            var genre = query.FirstOrDefault(new Genre() { Name = genreName });

            //TODO: betere check?
            if (genre.Id < 1)
            {
                _context.Genres.Add(genre);
                _context.SaveChanges();
            }

            return genre;
        }

        private Track GetOrCreateTrack(string fileName, string title, int number, int genreId, int discId)
        {
            //TODO: betere performance van maken door NIET eerst alles op te halen (IQueryable<Track>)
            IEnumerable<Track> query = _context.Tracks.ToList();
            query = query.Where(t => t.FileName == fileName);
            var track = query.FirstOrDefault(new Track()
            {
                FileName = fileName,
                Name = title,
                Number = number,
                GenreId = genreId,
                DiscId = discId
            });

            //TODO: betere check?
            if (track.Id < 1)
            {
                _context.Tracks.Add(track);
                _context.SaveChanges();
            }

            return track;
        }

        private Artist GetOrCreateArtist(string artistName)
        {
            //TODO: betere performance van maken door NIET eerst alles op te halen (IQueryable<Artist>)
            IEnumerable<Artist> query = _context.Artists.ToList();
            query = query.Where(a => a.Name == artistName);
            var artist = query.FirstOrDefault(new Artist() { Name = artistName });

            //TODO: betere check?
            if (artist.Id < 1)
            {
                _context.Artists.Add(artist);
                _context.SaveChanges();
            }

            return artist;
        }

        //TODO: disc?
        private Album GetOrCreateAlbum(string albumName, int year)
        {
            //TODO: betere performance van maken door NIET eerst alles op te halen (IQueryable<Album>)
            IEnumerable<Album> query = _context.Albums.ToList();
            query = query.Where(a => a.Name == albumName);
            var album = query.FirstOrDefault(new Album() { Name = albumName, ReleaseYear = year });

            //TODO: betere check?
            if (album.Id < 1)
            {
                _context.Albums.Add(album);
                _context.SaveChanges();
            }

            return album;
        }
        
        private Disc GetOrCreateDisc(int albumId, int number)
        {
            //TODO: betere performance van maken door NIET eerst alles op te halen (IQueryable<Disc>)
            IEnumerable<Disc> query = _context.Discs.ToList();
            query = query.Where(d => d.AlbumId == albumId && d.Number == number);
            var disc = query.FirstOrDefault(new Disc()
            {
                AlbumId = albumId,
                Number = number,
            });

            //TODO: betere check?
            if (disc.Id < 1)
            {
                _context.Discs.Add(disc);
                _context.SaveChanges();
            }

            return disc;
        }
    }
}
