using System.Collections.Generic;
using System.Security.Claims;
using STSMvc.Models.Entity;

namespace STS.Models.Interface
{
    public interface IUserRepository
    {
        bool IsValid(string username, string password);
        IEnumerable<Claim> GetClaims(string userName);
    }
}