using AlbumService.Models;
using AlbumService.SyncDataServices.Grpc;

namespace AlbumService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<IArtistDataClient>();

                var artists = grpcClient.ReturnAllArtists();

                SeedData(serviceScope.ServiceProvider.GetService<IAlbumRepo>(), artists);
            }
        }
        
        private static void SeedData(IAlbumRepo repo, IEnumerable<Artist> artists)
        {
            Console.WriteLine("Seeding new artists...");

            foreach (var art in artists)
            {
                if(!repo.ExternalArtistExists(art.ExternalId))
                {
                    repo.CreateArtist(art);
                }
                repo.SaveChanges();
            }
        }
    }
}