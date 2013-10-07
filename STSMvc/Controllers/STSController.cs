using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;
using STS.Models.Repository;
using STSMvc.FederationMetadata;
using STSMvc.TokenService;

namespace STSMvc.Controllers
{
    [Authorize]
    public class STSController : Controller
    {
        //
        // GET: /STS/


        public ActionResult Issue()
        {
            var message = WSFederationMessage.CreateFromUri(HttpContext.Request.Url);

            var signinMessage = message as SignInRequestMessage;
            if (signinMessage != null)
                return ProcessWSFederationSignIn(signinMessage, ClaimsPrincipal.Current);

            var signoutMessage = message as SignOutRequestMessage;
            if (signoutMessage != null)
                return ProcessWSFederationSignOut(signoutMessage);

            return View("Error");
        }

        private ActionResult ProcessWSFederationSignIn(SignInRequestMessage message, ClaimsPrincipal principal)
        {
            var tokenService = CustomSecurityTokenServiceConfiguration.Current.CreateSecurityTokenService();
            var responseMessgae = FederatedPassiveSecurityTokenServiceOperations.ProcessSignInRequest(
                message,
                principal,
                tokenService
                );
            return new ContentResult() {Content = responseMessgae.WriteFormPost()};
        }

        private ActionResult ProcessWSFederationSignOut(SignOutRequestMessage message)
        {
            FederatedAuthentication.SessionAuthenticationModule.SignOut();

            return Redirect(message.Reply);
        }

        [AllowAnonymous]
        public ContentResult FederationMetadata()
        {
            var generator = new FederatonMetadataGenerator(new STSConfigRepository());
            var metadata = generator.Generate();
            return new ContentResult()
            {
                Content = metadata,
                ContentEncoding = Encoding.UTF8,
                ContentType = "text/xml"
            };
        }


    }
}
