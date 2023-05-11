using AutoMapper;
using AlbumService.Dtos;
using AlbumService.Models;
//using ArtistService;

namespace AlbumService.Profiles
{
    public class AlbumsProfile : Profile
    {
        public AlbumsProfile()
        {
            // Source -> Target
            CreateMap<Artist, ArtistreadDto>();
            CreateMap<AlbumCreateDto, Album>();
            CreateMap<Album, AlbumReadDto>();
            CreateMap<ArtistPublishedDto, Artist>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));
            //CreateMap<GrpcArtistModel, Artist>()
            //    .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.ArtistId))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //    .ForMember(dest => dest.Albums, opt => opt.Ignore());
        }
    }
}