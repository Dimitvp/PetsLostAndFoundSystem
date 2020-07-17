using PetsLostAndFoundSystem.Infrastructure;
using PetsLostAndFoundSystem.Controllers;

namespace PetsLostAndFoundSystem.Admin.Controllers
{
    [AuthorizeAdministrator]
    public abstract class AdministrationController : CommunicationBaseController
    {
    }
}
