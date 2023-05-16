using AlbumService.Models;

namespace AlbumService.Data
{
    public class AlbumRepo : IAlbumRepo
    {
        private readonly AppDbContext _context;

        public AlbumRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateAlbum(Guid ArtistId, Album Album)
        {
            if (Album == null)
            {
                throw new ArgumentNullException(nameof(Album));
            }

            Album.ArtistId = ArtistId;
            _context.Albums.Add(Album);
        }

        public void CreateArtist(Artist art)
        {
            if (art == null)
            {
                throw new ArgumentNullException(nameof(art));
            }
            _context.Artists.Add(art);
        }

        public bool ExternalArtistExists(Guid externalArtistId)
        {
            return _context.Artists.Any(ar => ar.ExternalId == externalArtistId);
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return _context.Artists.ToList();
        }

        public Album GetAlbum(Guid ArtistId, Guid AlbumId)
        {
            return _context.Albums
                .Where(al => al.ArtistId == ArtistId && al.Id == AlbumId).FirstOrDefault();
        }
        public IEnumerable<Album> GetAlbums()
        {
            return _context.Albums;
        }
        public IEnumerable<Album> GetAlbumsForArtist(Guid ArtistId)
        {
            return _context.Albums
                .Where(al => al.ArtistId == ArtistId)
                .OrderBy(al => al.Artist.Name);
        }
        public void DeleteAlbum(Guid AlbumId)
        {
            var delAlbum = _context.Albums.Where(al => al.Id == AlbumId).Single();
            _context.Albums.Remove(delAlbum);
        }

        public void DeleteAllArtistsAlbums(Guid ArtistId)
        {
            var delAlbums = _context.Albums.Where(al => al.ArtistId == ArtistId);
            _context.Albums.RemoveRange(delAlbums);
        }
        public bool ArtistExits(Guid ArtistId)
        {
            return _context.Artists.Any(ar => ar.Id == ArtistId);
        }
        public bool AlbumExists(Guid albumId)
        {
            return _context.Albums.Any(al => al.Id == albumId);
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}