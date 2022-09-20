using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Project.API.v.Security
{
    public class APIAuthorizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string actionroles = Roles;
            string userName = HttpContext.Current.User.Identity.Name;
            UsersDAL userDAL = new UsersDAL();
            DAL.Users user = userDAL.GetUserByName(userName);
            if (user != null && actionroles.Contains(user.Role))
            {
               
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            
        }
    }
}