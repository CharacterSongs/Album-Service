using AutoMapper;
using AlbumService.Models;
using Grpc.Net.Client;
using ArtistService;

namespace AlbumService.SyncDataServices.Grpc
{
    public class ArtistDataClient : IArtistDataClient
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ArtistDataClient(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public IEnumerable<Artist> ReturnAllArtists()
        {
            Console.WriteLine($"--> Calling GRPC Service {_configuration["GrpcArtist"]}");
            var channel = GrpcChannel.ForAddress(_configuration["GrpcArtist"]);
            var client = new GrpcArtist.GrpcArtistClient(channel);
            var request = new GetAllRequest();

            try
            {
                var reply = client.GetAllArtists(request);
                return _mapper.Map<IEnumerable<Artist>>(reply.Artist);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not call GRPC Server {ex.Message}");
                return null;
            }
        }
    }
}