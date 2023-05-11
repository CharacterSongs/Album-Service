using System.ComponentModel.DataAnnotations;

namespace AlbumService.Dtos
{
    public class AlbumCreateDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate{get;set;}
    }
}
