using System.Collections.Generic;
using System.Security.Claims;
using Managers.Interface;
using Managers.Modals;

namespace Managers
{
    public class TokenManager : ITokenManager
    {

        public ClaimProperties ConvertClaims(IEnumerable<Claim> claims)
        {
            ClaimProperties userProperties = new ClaimProperties();

            foreach (var claim in claims)
            {
                if (userProperties.GetType().GetProperty(claim.Type) != null)
                {

                    var propertyInfo = userProperties.GetType().GetProperty(claim.Type);
                    propertyInfo.SetValue(userProperties, claim.Value, null);
                }
            }

            return userProperties;

        }
    }
}
