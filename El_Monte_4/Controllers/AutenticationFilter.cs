using El_Monte_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace El_Monte_4.Controllers
{
    public class AutenticationFilter : AuthorizeAttribute
    {
        private CarcelDbContext context = new CarcelDbContext();

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string AccessTokenFromRequest = "";

            if (actionContext.Request.Headers.Authorization != null)
            {

                AccessTokenFromRequest = actionContext.Request.Headers.Authorization.Parameter;

                if (context.Usuarios.Where(u => u.Token == AccessTokenFromRequest).Count() > 0)
                {
                    return true;
                }
            }
            return false;
              }
    }
}