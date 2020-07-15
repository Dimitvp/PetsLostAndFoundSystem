using PetsLostAndFoundSystem.Data.Models;
using PetsLostAndFoundSystem.Models.Pets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Services.Contracts
{
    public interface IPetService
    {
        Task<Pet> Find(int id);
        Task<IEnumerable<PetOutputModel>> GetAll();
    }
}
