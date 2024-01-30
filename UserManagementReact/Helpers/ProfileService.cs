using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UserManagementReact.Entities;

namespace UserManagementReact.Helpers
{
    public class ProfileService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> GetClaimsPrincipalAsync(ApplicationUser user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                // Add additional claims as needed
            };

            var claimsIdentity = new ClaimsIdentity(claims, "custom", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return new ClaimsPrincipal(claimsIdentity);
        }

        public async Task<bool> IsUserActiveAsync(ApplicationUser user)
        {
            return user != null && await _userManager.IsInRoleAsync(user, "ActiveRole");
        }
    }
}