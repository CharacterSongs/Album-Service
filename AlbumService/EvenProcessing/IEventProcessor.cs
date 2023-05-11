namespace AlbumService.EventProcessing
{
    public interface IEventProcessor
    {
        void ProcessEvent(string message);
    }
}