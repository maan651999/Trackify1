using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Trackify.Web.Filters
{
    public class JwtAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Safely read cookie
            string token = null;
            context.HttpContext.Request.Cookies.TryGetValue("jwt", out token);

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedObjectResult("Token Missing");
                return;
            }

            var userName = JwtRefreshMiddleware.ValidateToken(token);

            if (string.IsNullOrEmpty(userName))
            {
                context.Result = new UnauthorizedObjectResult("Invalid Token");
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}