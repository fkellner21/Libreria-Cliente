using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebAppli.Filter
{
    public class AutEncargado : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.HttpContext.Session.GetString("rol") != "Encargado")
            {
                context.HttpContext.Session.Clear();
                context.Result = new RedirectResult("/Usuario/Index");
            }


        }
    }
}
