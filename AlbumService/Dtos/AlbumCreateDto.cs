using System.ComponentModel.DataAnnotations;

namespace AlbumService.Dtos
{
    public class AlbumCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
