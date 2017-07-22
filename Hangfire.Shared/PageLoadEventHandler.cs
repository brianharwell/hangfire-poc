using System;

namespace Hangfire.Shared
{
    public class PageLoadEventHandler : IPageLoadEventHandler
    {
        public void HandleEvent(PageLoadEvent pageLoadEvent)
        {
            var status = pageLoadEvent.HasParameters ? "FAILED" : "SUCCEEDED";

            Console.WriteLine($"{DateTime.Now}: {status}: Controller: {pageLoadEvent.Controller}, Action: {pageLoadEvent.Action}");

            throw new Exception("Request has parameters");
        }
    }
}