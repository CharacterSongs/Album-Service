using System.ComponentModel.DataAnnotations;

namespace AlbumService.Models
{
    public class Artist
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int ExternalId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Album> Albums {get;set;} = new List<Album>();
    }
}