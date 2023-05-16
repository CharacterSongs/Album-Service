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
        bool ArtistExits(Guid ArtistId);
        bool ExternalArtistExists(Guid externalArtistId);

        // Albums
        IEnumerable<Album> GetAlbumsForArtist(Guid ArtistId);
        Album GetAlbum(Guid ArtistId, Guid AlbumId);
        IEnumerable<Album> GetAlbums();
        void CreateAlbum(Guid ArtistId, Album Album);
        void DeleteAlbum(Guid AlbumId);
        void DeleteAllArtistsAlbums(Guid ArtistId);
        bool AlbumExists(Guid albumId);
    }
}