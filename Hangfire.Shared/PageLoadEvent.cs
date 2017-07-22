namespace Hangfire.Shared
{
    public class PageLoadEvent
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool HasParameters { get; set; }
    }
}
