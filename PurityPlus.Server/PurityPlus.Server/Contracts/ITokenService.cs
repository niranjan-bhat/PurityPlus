using PurityPlus.Database.Entity;
using System.Security.Claims;

namespace PurityPlus.Server.Contracts
{
    public interface ITokenService
    {
        string GenerateAccessToken(ApplicationUser user, string[] userRoles);
        string GenerateRefreshToken();
        IEnumerable<Claim> GetClaimsFromAccessToken(string accessToken);
    }
}
