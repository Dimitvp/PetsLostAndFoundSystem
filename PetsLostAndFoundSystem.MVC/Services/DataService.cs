//using System.Linq;
//using System.Threading.Tasks;

//using PetsLostAndFoundSystem.MVC.Data;
//using PetsLostAndFoundSystem.MVC.Services.Contracts;

//namespace PetsLostAndFoundSystem.MVC.Services
//{
//    public abstract class DataService<TEntity> : IDataService<TEntity>
//        where TEntity : class
//    {
//        protected DataService(PetsLostAndFoundDbContext db) => this.Data = db;

//        protected PetsLostAndFoundDbContext Data { get; }

//        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

//        public async Task Save(
//            TEntity entity)
//        {
//            this.Data.Update(entity);

//            await this.Data.SaveChangesAsync();
//        }
//    }
//}