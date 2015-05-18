using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Tamlin.MCServer.Web.Models;
using Nancy.ModelBinding;
using Nancy.Responses;
using Nancy.Extensions;
using Nancy.Authentication.Forms;

namespace Tamlin.MCServer.Web.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule()
        {

            Get["/login"] = parameters =>
            {
                return View["index", new LoginModel()];
            };

            Post["/login"] = parameters =>
            {
                var model = this.Bind<LoginModel>();

                //TODO: Get the user from the databae and actually compare the passwords
                if(model.UserName == "justin" && model.Password == "finch")
                {
                    return this.LoginAndRedirect(Guid.NewGuid(), fallbackRedirectUrl: "/");
                }
                else
                {
                    model.ErrorMsg = "Invalid Username or Password";
                }

                return View["index", model];

                //UserAccount account;
                //if (userAccountService.AuthenticateWithUsernameOrEmail(model.UserName, model.Password, out account))
                //{
                //    authService.SignIn(account, false);

                //    string returnUrl = parameters.ReturnUrl;
                //    if (Context.IsLocalUrl(returnUrl))
                //    {
                //        return Response.AsRedirect(returnUrl);
                //    }

                //    return Response.AsRedirect("/");
                //}
                //else
                //{
                //    
                //}


                
            };

            Get["/logout"] = parameters =>
            {
                // Called when the user clicks the sign out button in the application. Should
                // perform one of the Logout actions (see below)
                return this.LogoutAndRedirect("/login");
            };
        }
    }
}
