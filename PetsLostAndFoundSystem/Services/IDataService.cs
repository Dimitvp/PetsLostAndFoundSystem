using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Services
{
    public interface IDataService<in TEntity>
         where TEntity : class
    {
        Task Save(TEntity entity);
    }
}
