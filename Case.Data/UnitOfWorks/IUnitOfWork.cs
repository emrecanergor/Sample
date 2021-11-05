using Case.Data.Repositories.Abstract;
using System.Threading.Tasks;

namespace Case.Data.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; } 

        Task CommitAsync();

        void Commit();
    }
}
