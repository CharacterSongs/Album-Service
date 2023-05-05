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

        public void CreateAlbum(int ArtistId, Album Album)
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
            if(art == null)
            {
                throw new ArgumentNullException(nameof(art));
            }
            _context.Artists.Add(art);
        }

        public bool ExternalArtistExists(int externalArtistId)
        {
            return _context.Artists.Any(ar => ar.ExternalId == externalArtistId);
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return _context.Artists.ToList();
        }

        public Album GetAlbum(int ArtistId, int AlbumId)
        {
            return _context.Albums
                .Where(al => al.ArtistId == ArtistId && al.Id == AlbumId).FirstOrDefault();
        }

        public IEnumerable<Album> GetAlbumsForArtist(int ArtistId)
        {
            return _context.Albums
                .Where(al => al.ArtistId == ArtistId)
                .OrderBy(al => al.Artist.Name);
        }

        public bool ArtistExits(int ArtistId)
        {
            return _context.Artists.Any(ar => ar.Id == ArtistId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}