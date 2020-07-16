using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.MVC.Services.Contracts
{
    public interface IDataService<in TEntity>
        where TEntity : class
    {
        Task Save(TEntity entity);
    }
}
