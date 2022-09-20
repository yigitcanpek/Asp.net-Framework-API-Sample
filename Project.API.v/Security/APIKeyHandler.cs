using DAL;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Project.API.v.Security
{
    public class APIKeyHandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            NameValueCollection querystring =   request.RequestUri.ParseQueryString();
            string apiKey = querystring["apiKey"];
            UsersDAL userDAL = new UsersDAL();
            Users user = userDAL.GetUserByApiKey(apiKey);
            if (user!=null)
            {
               ClaimsPrincipal principal = new ClaimsPrincipal(new GenericIdentity(user.Name, "APIKey"));
                HttpContext.Current.User = principal;
            }
            
            return base.SendAsync(request, cancellationToken);
        }
    }
}