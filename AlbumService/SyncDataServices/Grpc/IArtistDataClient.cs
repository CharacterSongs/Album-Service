using System.Collections.Generic;
using AlbumService.Models;

namespace AlbumService.SyncDataServices.Grpc
{
    public interface IArtistDataClient
    {
        IEnumerable<Artist> ReturnAllArtists();
    }
}