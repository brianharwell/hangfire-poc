namespace Hangfire.Shared
{
    public interface IPageLoadEventHandler
    {
        void HandleEvent(PageLoadEvent pageLoadEvent);
    }
}
