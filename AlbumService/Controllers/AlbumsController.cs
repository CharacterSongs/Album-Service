using AlbumService.Data;
using AlbumService.Dtos;
using AlbumService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlbumService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumRepo _repository;
        private readonly IMapper _mapper;

        public AlbumsController(IAlbumRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<AlbumReadDto>> GetAlbums()
        {
            var Albums = _repository.GetAlbums();

            return Ok(_mapper.Map<IEnumerable<AlbumReadDto>>(Albums));
        }
        
        [HttpDelete("{albumId}", Name = "DeleteAlbum")]
        public ActionResult DeleteAlbum(Guid albumId)
        {
            if (!_repository.AlbumExists(albumId))
            {
                return NotFound();
            }

            _repository.DeleteAlbum(albumId);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}