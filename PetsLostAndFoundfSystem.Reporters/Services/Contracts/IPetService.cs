using System.Collections.Generic;
using System.Threading.Tasks;

using PetsLostAndFoundSystem.Reporters.Data.Models;
using PetsLostAndFoundSystem.Reporters.Models.Pets;

namespace PetsLostAndFoundSystem.Reporters.Services.Contracts
{
    public interface IPetService
    {
        Task<Pet> Find(int id);
        Task<IEnumerable<PetOutputModel>> GetAll();
    }
}
