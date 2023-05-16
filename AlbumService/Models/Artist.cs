using System.ComponentModel.DataAnnotations;

namespace AlbumService.Models
{
    public class Artist
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid ExternalId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Album> Albums {get;set;} = new List<Album>();
    }
}