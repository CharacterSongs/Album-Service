using System.ComponentModel.DataAnnotations;

namespace AlbumService.Models
{
    public class Album
    {
        [Key]
        [Required]
        public Guid Id {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public Guid ArtistId {get; set;}
        [Required]
        public DateTime ReleaseDate {get; set;}
        public Artist Artist {get; set;}
    }
}