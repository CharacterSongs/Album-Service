namespace AlbumService.Dtos
{
    public class AlbumReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate {get;set;}
        public Guid ArtistId{get;set;}
    }
}