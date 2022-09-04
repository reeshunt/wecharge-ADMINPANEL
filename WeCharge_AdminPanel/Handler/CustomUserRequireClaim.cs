using Microsoft.AspNetCore.Authorization;
namespace WeCharge_AdminPanel.Handler
{
    public class CustomUserRequireClaim:IAuthorizationRequirement
    {
        public string ClaimType { get; }
        public CustomUserRequireClaim(string claimType)
        {
            ClaimType = claimType;
        }
    }
}
