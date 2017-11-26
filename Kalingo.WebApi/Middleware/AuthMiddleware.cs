using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Kalingo.WebApi.Middleware
{
    public class AuthMiddleware : OwinMiddleware
    {
        private readonly Auth _auth;

        public AuthMiddleware(OwinMiddleware next) : base(next)
        {
            _auth = new Auth();
        }

        public override async Task Invoke(IOwinContext context)
        {
            if (AuthenticationPath(context.Request))
            {
                if (!_auth.Validate(context.Request))
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    return;
                }
            }

            await Next.Invoke(context);

            if (context.Request.Uri.PathAndQuery.Contains("/users/Get"))
            {
                if (context.Response.StatusCode == 200)
                {
                    _auth.GenerateAuth(context.Response);
                }
            }
        }

        public bool AuthenticationPath(IOwinRequest request)
        {
            return request.Uri.PathAndQuery.Contains("/users/")
                   && !request.Uri.PathAndQuery.Contains("/users/Get")
                   && !request.Uri.PathAndQuery.Contains("/users/Add")
                   || request.Uri.PathAndQuery.Contains("/minesboom/")
                   || request.Uri.PathAndQuery.Contains("/captcha/")
                   && !request.Uri.PathAndQuery.Contains("/users/Submit")
                   || request.Uri.PathAndQuery.Contains("/voucher/")
                   && !request.Uri.PathAndQuery.Contains("/voucher/Get")
                   || request.Uri.PathAndQuery.Contains("/country/");
        }
    }
}