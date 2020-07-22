using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.EntityFrameworkCore;
using PetsLostAndFoundSystem.Reporters.Data;
using PetsLostAndFoundSystem.Reporters.Data.Models;
using PetsLostAndFoundSystem.Reporters.Models.Pets;
using PetsLostAndFoundSystem.Reporters.Services.Contracts;
using PetsLostAndFoundSystem.Services;

namespace PetsLostAndFoundSystem.Reporters.Services.PetService
{
    public class PetService : DataService<Pet>, IPetService
    {
        private readonly IMapper mapper;

        public PetService(ReportersDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<Pet> Find(int id)
            => await this
            .All()
            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<PetOutputModel>> GetAll()
            => await this.mapper
            .ProjectTo<PetOutputModel>(this
                    .All())
                .ToListAsync();
    }
}
