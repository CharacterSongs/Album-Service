using AlbumService.Data;
using AlbumService.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlbumService.Controllers
{
    [Route("api/a/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IAlbumRepo _repository;
        private readonly IMapper _mapper;
        public ArtistController(IAlbumRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ArtistreadDto>> GetArtists()
        {
            Console.WriteLine("--> Getting Artists from AlbumsService");

            var artistItems = _repository.GetAllArtists();

            return Ok(_mapper.Map<IEnumerable<ArtistreadDto>>(artistItems));
        }
        [HttpDelete("{artistId}", Name = "DeleteAlbumsForArtist")]
        public ActionResult DeleteAlbumsForArtist(Guid artistId)
        {
            Console.WriteLine($"--> Hit DeleteAlbumsForArtist: {artistId}");

            if (!_repository.ArtistExits(artistId))
            {
                return NotFound();
            }

            _repository.DeleteAllArtistsAlbums(artistId);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpPost]
        public ActionResult TestInboundCOnnection()
        {
            Console.WriteLine("--> Inbound POST # Album Service");
            return Ok("Inbound test of from Artist controller");
        }
    }
}