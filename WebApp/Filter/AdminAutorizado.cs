using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Filter
{
    public class AdminAutorizado : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.HttpContext.Session.GetString("super") != "True")
            {
                context.HttpContext.Session.Clear();
                context.Result = new RedirectResult("/Index/Login");
            }


        }
    }
}
