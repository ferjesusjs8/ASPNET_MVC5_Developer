using System.Web.Mvc;
using System.Web.Routing;

namespace AluraMVC5.Filters
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session["usuarioLogado"];
            if (usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new { controller = "Login", action = "Index" }
                   )
                );
            }
        }
    }
}