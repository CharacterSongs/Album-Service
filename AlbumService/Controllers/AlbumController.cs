using AlbumService.Data;
using AlbumService.Dtos;
using AlbumService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlbumService.Controllers
{
    [Route("api/a/artist/{artistId}/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepo _repository;
        private readonly IMapper _mapper;

        public AlbumController(IAlbumRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlbumReadDto>> GetAlbumsForArtist(int artistId)
        {
            Console.WriteLine($"--> Hit GetAlbumsForArtist: {artistId}");

            if (!_repository.ArtistExits(artistId))
            {
                return NotFound();
            }

            var Albums = _repository.GetAlbumsForArtist(artistId);

            return Ok(_mapper.Map<IEnumerable<AlbumReadDto>>(Albums));
        }

        [HttpGet("{AlbumId}", Name = "GetAlbumForArtist")]
        public ActionResult<AlbumReadDto> GetAlbumForArtist(int artistId, int AlbumId)
        {
            Console.WriteLine($"--> Hit GetAlbumForartist: {artistId} / {AlbumId}");

            if (!_repository.ArtistExits(artistId))
            {
                return NotFound();
            }

            var album = _repository.GetAlbum(artistId, AlbumId);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AlbumReadDto>(album));
        }

        [HttpPost]
        public ActionResult<AlbumReadDto> CreateAlbumForArtist(int artistId, AlbumCreateDto AlbumDto)
        {
            Console.WriteLine($"--> Hit CreateAlbumForArtist: {artistId}");

            if (!_repository.ArtistExits(artistId))
            {
                return NotFound();
            }

            var album = _mapper.Map<Album>(AlbumDto);

            _repository.CreateAlbum(artistId, album);
            _repository.SaveChanges();

            var albumReadDto = _mapper.Map<AlbumReadDto>(album);

            return CreatedAtRoute(nameof(GetAlbumForArtist),
                new { artistId = artistId, albumId = albumReadDto.Id }, albumReadDto);
        }

    }
}