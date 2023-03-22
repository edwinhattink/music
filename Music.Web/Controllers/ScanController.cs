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
        public async Task<ActionResult<IEnumerable<object>>> Scan()
        {
            var mp3s = Directory.GetFiles("C:\\git\\Music\\Music.Web\\wwwroot\\Music", "*.mp3", SearchOption.AllDirectories);

            foreach (var mp3Path in mp3s)
            {
                var tfile = TagLib.File.Create(mp3Path);

                var genre = await GetOrCreateGenre(tfile.Tag.JoinedGenres);
                var album = await GetOrCreateAlbum(tfile.Tag.Album, checked((int)tfile.Tag.Year));
                var artist = await GetOrCreateArtist(tfile.Tag.JoinedPerformers);
                var albumArtist = await GetOrCreateArtist(tfile.Tag.JoinedAlbumArtists);

                var disc = await GetOrCreateDisc(album.Id, checked((int)tfile.Tag.Disc));

                var track = await GetOrCreateTrack(mp3Path, tfile.Tag.Title, checked((int) tfile.Tag.Track), genre.Id, disc.Id);

                await GetOrCreateDiscContribution(albumArtist.Id, disc.Id);
                await GetOrCreateContribution(artist.Id, track.Id);              
            }

            return mp3s;
        }

        private async Task<Contribution> GetOrCreateContribution(int artistId, int trackId)
        {
            var contribution = await _context.Contributions
                .Where(c => c.ArtistId == artistId && c.TrackId == trackId)
                .SingleOrDefaultAsync();

            if (contribution == null)
            {
                contribution = new Contribution()
                {
                    ArtistId = artistId,
                    TrackId = trackId,
                    ContributionType = ContributionType.Main
                };
                _context.Contributions.Add(contribution);
                await _context.SaveChangesAsync();
            }

            return contribution;
        }

        private async Task<DiscContribution> GetOrCreateDiscContribution(int artistId, int discId)
        {
            var contribution = await _context.DiscContributions
                .Where(c => c.ArtistId == artistId && c.DiscId == discId)
                .SingleOrDefaultAsync();

            if (contribution == null)
            {
                contribution = new DiscContribution()
                {
                    ArtistId = artistId,
                    DiscId = discId
                };
                _context.DiscContributions.Add(contribution);
                await _context.SaveChangesAsync();
            }

            return contribution;
        }

        private async Task<Genre> GetOrCreateGenre(string genreName)
        {
            var genre = await _context.Genres
                .Where(g => g.Name == genreName)
                .SingleOrDefaultAsync();

            if (genre == null)
            {
                genre = new Genre() { Name = genreName };

                _context.Genres.Add(genre);
                await _context.SaveChangesAsync();
            }

            return genre;
        }

        private async Task<Track> GetOrCreateTrack(string fileName, string title, int number, int genreId, int discId)
        {
            var track = await _context.Tracks
                .Where(t => t.FileName == fileName)
                .SingleOrDefaultAsync();

            if (track == null)
            {
                track = new Track()
                {
                    FileName = fileName,
                    Name = title,
                    Number = number,
                    GenreId = genreId,
                    DiscId = discId
                };
                _context.Tracks.Add(track);
                await _context.SaveChangesAsync();
            }

            return track;
        }

        private async Task<Artist> GetOrCreateArtist(string artistName)
        {
            var artist = await _context.Artists
                .Where(a => a.Name == artistName)
                .SingleOrDefaultAsync();

            if (artist == null)
            {
                artist = new Artist() { Name = artistName };
                _context.Artists.Add(artist);
                await _context.SaveChangesAsync();
            }

            return artist;
        }

        private async Task<Album> GetOrCreateAlbum(string albumName, int year)
        {
            var album = await _context.Albums
                .Where(a => a.Name == albumName)
                .SingleOrDefaultAsync();

            if (album == null)
            {
                album = new Album() { Name = albumName, ReleaseYear = year };
                _context.Albums.Add(album);
                await _context.SaveChangesAsync();
            }

            return album;
        }

        private async Task<Disc> GetOrCreateDisc(int albumId, int number)
        {
            var disc = await _context.Discs
                .Where(d => d.AlbumId == albumId && d.Number == number)
                .SingleOrDefaultAsync();

            if (disc == null)
            {
                disc = new Disc()
                {
                    AlbumId = albumId,
                    Number = number,
                };
                _context.Discs.Add(disc);
                await _context.SaveChangesAsync();
            }

            return disc;
        }
    }
}
