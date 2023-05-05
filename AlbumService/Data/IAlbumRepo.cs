using AlbumService.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumService.Data
{
    public interface IAlbumRepo
    {
        bool SaveChanges();

        // Artists
        IEnumerable<Artist> GetAllArtists();
        void CreateArtist(Artist plat);
        bool ArtistExits(int ArtistId);
        bool ExternalArtistExists(int externalArtistId);

        // Albums
        IEnumerable<Album> GetAlbumsForArtist(int ArtistId);
        Album GetAlbum(int ArtistId, int AlbumId);
        void CreateAlbum(int ArtistId, Album Album);
    }
}