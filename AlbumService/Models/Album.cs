using System.ComponentModel.DataAnnotations;

namespace AlbumService.Models
{
    public class Album
    {
        [Key]
        [Required]
        public int Id {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public int ArtistId {get; set;}
        [Required]
        public DateTime ReleaseDate {get; set;}
        public Artist Artist {get; set;}
    }
}