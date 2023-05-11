using System.Text.Json;
using AlbumService.Data;
using AlbumService.Dtos;
using AlbumService.Models;
using AutoMapper;

namespace AlbumService.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, AutoMapper.IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.ArtistPublished:
                    addArtist(message);
                    break;
                default:
                    break;
            }
        }
        private EventType DetermineEvent(string notifcationMessage)
        {
            Console.WriteLine("--> Determining Event");

            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notifcationMessage);

            switch (eventType.Event)
            {
                case "Artist_Published":
                    Console.WriteLine("--> Artist Published Event Detected");
                    return EventType.ArtistPublished;
                default:
                    Console.WriteLine("--> Could not determine the event type");
                    return EventType.Undetermined;
            }
        }
        private void addArtist(string artistPublishedMessage)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IAlbumRepo>();

                var artistPublishedDto = JsonSerializer.Deserialize<ArtistPublishedDto>(artistPublishedMessage);

                try
                {
                    var art = _mapper.Map<Artist>(artistPublishedDto);
                    if (!repo.ExternalArtistExists(art.ExternalId))
                    {
                        repo.CreateArtist(art);
                        repo.SaveChanges();
                        Console.WriteLine("--> Artist added!");
                    }
                    else
                    {
                        Console.WriteLine("--> Artist already exisits...");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not add Platform to DB {ex.Message}");
                }
            }
        }
        enum EventType
        {
            ArtistPublished,
            Undetermined
        }
    }
}