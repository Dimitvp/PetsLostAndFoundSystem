using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Services.Contracts
{
    public interface IDataService<in TEntity>
        where TEntity : class
    {
        Task Save(TEntity entity);
    }
}
