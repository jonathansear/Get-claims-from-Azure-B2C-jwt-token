using System.Collections.Generic;
using System.Security.Claims;
using Managers.Modals;

namespace Managers.Interface
{
    public interface ITokenManager
    {
        ClaimProperties ConvertClaims(IEnumerable<Claim> Collection);
    }
}
