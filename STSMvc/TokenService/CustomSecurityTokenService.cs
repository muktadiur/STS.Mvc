using System.ComponentModel;
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Security.Claims;


namespace STSMvc.TokenService
{
    public class CustomSecurityTokenService:SecurityTokenService
    {

        public CustomSecurityTokenService(SecurityTokenServiceConfiguration configuration)
            : base(configuration)
        {
        }

      
        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken rst)
        {
            return new Scope()
                       {
                           AppliesToAddress = rst.AppliesTo.Uri.AbsoluteUri,
                           ReplyToAddress = rst.AppliesTo.Uri.AbsoluteUri,
                           TokenEncryptionRequired = false,
                           SigningCredentials = base.SecurityTokenServiceConfiguration.SigningCredentials

                       };
        }


        protected override ClaimsIdentity GetOutputClaimsIdentity(ClaimsPrincipal principal, RequestSecurityToken request, Scope scope)
        {
            return principal.Identity as ClaimsIdentity;
        }
    }
}