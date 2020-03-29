using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace RSML_web_app
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                System.Diagnostics.Debug.WriteLine("IN HEADER NULL");
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                // Gets header parameters  
                System.Diagnostics.Debug.WriteLine("IN ELSE");
                string authenticationString = actionContext.Request.Headers.Authorization.Parameter;
                string originalString = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationString));

                // Gets username and password  
                string username = originalString.Split(':')[0];
                string password = originalString.Split(':')[1];
                System.Diagnostics.Debug.WriteLine("USERNAME: ", username);
                System.Diagnostics.Debug.WriteLine("PASSWORD: ", password);

                // Validate username and password  
                if (username != "TeamMeijer" || password != "Need Anything?")
                {
                    // returns unauthorized error  
                    System.Diagnostics.Debug.WriteLine("UNAUTHORIZED ACCOUNT");
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }

            base.OnAuthorization(actionContext);
        }
    }
}