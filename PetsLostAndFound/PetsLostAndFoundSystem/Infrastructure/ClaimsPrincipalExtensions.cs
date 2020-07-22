using System.Security.Claims;

namespace PetsLostAndFoundSystem.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdministrator(this ClaimsPrincipal user)
            => user.IsInRole(Constants.AdministratorRoleName);

        public static bool IsAuthenticated(this ClaimsPrincipal user)
            => user.Identity.IsAuthenticated;
    }
}
