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
using Tamlin.MCServer.Data.Users;

namespace Tamlin.MCServer.Web.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule(IUserRepo userRepo)
        {

            Get["/login"] = parameters =>
            {
                return View["index", new LoginModel()];
            };

            Post["/login"] = parameters =>
            {
                var model = this.Bind<LoginModel>();

                var user = userRepo.GetByUsername(model.UserName);

                if(user != null && user.cpassword.Trim() == model.Password)
                {
                    return this.LoginAndRedirect(Guid.NewGuid(), fallbackRedirectUrl: "/");
                }
                else
                {
                    model.ErrorMsg = "Invalid Username or Password";
                }

                return View["index", model];
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
