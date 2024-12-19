using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Filter
{
    public class Admin : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            if (context.HttpContext.Session.GetString("rol") != "Admin")
            {
                context.HttpContext.Session.Clear();
                context.Result = new RedirectResult("/Index/Login");
            }


        }
    }
}
