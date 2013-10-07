using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using STS.Models.Interface;
using STS.Models.Entity;
using STS.Models.Helper;

namespace STS.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        public bool IsValid(string userName, string password)
        {
            var ctx = new DataContext();
            var user = ctx.Users.FirstOrDefault(u => u.UserId == userName);
            if (user != null)
            {
                if (user.Password.Equals(EncryptionProvider.GetHashValue(password), StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
                else return false;
            }
            else return false;


        }

        public IEnumerable<Claim> GetClaims(string userName)
        {
            var ctx = new DataContext();
            var user = ctx.Users.FirstOrDefault(u => u.UserId == userName);

            List<Claim> claims = new List<Claim>();
            if (user != null) {
                claims.Add(new Claim(IMSClaimTypes.UserName, userName));
                claims.Add(new Claim(IMSClaimTypes.FirstName, user.FirstName == null ? "" : user.FirstName));
                claims.Add(new Claim(IMSClaimTypes.LastName, user.LastName == null ? "" : user.LastName));
                claims.Add(new Claim(IMSClaimTypes.Email, user.Email == null ? "" : user.Email));
                claims.Add(new Claim(IMSClaimTypes.RoleId, user.RoleId.ToString()));
                claims.Add(new Claim(IMSClaimTypes.Active, user.Active.ToString()));
                claims.Add(new Claim(IMSClaimTypes.ReceiveEmailAlert, user.ReceiveEmailAlert.ToString()));
                claims.Add(new Claim(IMSClaimTypes.RoleDescription, user.RoleDescription == null ? "" : user.RoleDescription));
                claims.Add(new Claim(IMSClaimTypes.GeoDescription, user.GeoDescription == null ? "" : user.GeoDescription));
                claims.Add(new Claim(IMSClaimTypes.GeoCode, user.GeoCode == null ? "" : user.GeoCode));
                claims.Add(new Claim(IMSClaimTypes.DefaultNav, user.DefaultNav.ToString()));
            }

            return claims;
        }


        
    }
}