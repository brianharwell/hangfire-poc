using System.Web.Mvc;
using Hangfire.Shared;

namespace Hangfire.Web.Controllers.Filters
{
    public class PageLoadActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var pageLoadEvent = new PageLoadEvent();

            pageLoadEvent.Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            pageLoadEvent.Action = filterContext.ActionDescriptor.ActionName;

            if (filterContext.RouteData.Values.ContainsKey("id"))
            {
                pageLoadEvent.HasParameters = true;
            }

            BackgroundJob.Enqueue<IPageLoadEventHandler>(x => x.HandleEvent(pageLoadEvent));
        }
    }
}
