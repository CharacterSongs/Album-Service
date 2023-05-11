namespace AlbumService.Dtos
{
    public class AlbumReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate {get;set;}
        public int ArtistId{get;set;}
    }
}