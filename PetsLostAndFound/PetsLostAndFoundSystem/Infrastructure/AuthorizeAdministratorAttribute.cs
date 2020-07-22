using Microsoft.AspNetCore.Authorization;

namespace PetsLostAndFoundSystem.Infrastructure
{
    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = Constants.AdministratorRoleName;
    }
}
