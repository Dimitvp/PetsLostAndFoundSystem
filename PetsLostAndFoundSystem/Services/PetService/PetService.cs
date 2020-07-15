using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetsLostAndFoundSystem.Data;
using PetsLostAndFoundSystem.Data.Models;
using PetsLostAndFoundSystem.Models.Pets;
using PetsLostAndFoundSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Services.PetService
{
    public class PetService : DataService<Pet>, IPetService
    {
        private readonly IMapper mapper;

        public PetService(PetsLostAndFoundDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<Pet> Find(int id)
            => await this
            .Data
            .Pets
            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<PetOutputModel>> GetAll()
            => await this.mapper
            .ProjectTo<PetOutputModel>(this
                    .Data.Pets)
                .ToListAsync();
    }
}
