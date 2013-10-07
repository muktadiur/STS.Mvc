using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using STSMvc.Models;

using System.Threading;
using STS.Models.Repository;
using STS.Models.Entity;

namespace STSMvc.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserRepository _userRep;
        //
        // GET: /Account/


        public AccountController()
        {
            _userRep = new UserRepository();
            AntiForgeryConfig.UniqueClaimTypeIdentifier = IMSClaimTypes.UserName;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (_userRep.IsValid(model.UserName,model.Password))
            {
                SetSessionCokie(model.UserName,model.RememberMe);
                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }


        private void SetSessionCokie(string userName,bool rememberMe)
        {
            var claims = _userRep.GetClaims(userName);
            var principal =
                new ClaimsPrincipal(new ClaimsIdentity(claims, "Forms", ClaimTypes.Name, ClaimTypes.Role));
            
            var sessionToken = new SessionSecurityToken(principal, TimeSpan.FromHours(24)) {IsPersistent = rememberMe};
         
            FederatedAuthentication.SessionAuthenticationModule.WriteSessionTokenToCookie(sessionToken);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            FederatedAuthentication.SessionAuthenticationModule.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            
            return RedirectToAction("Index", "Home");
        }

    
    }
}
