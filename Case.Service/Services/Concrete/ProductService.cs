using Case.Data.Repositories.Abstract;
using Case.Data.UnitOfWorks;
using Case.Domain.Entity;
using Case.Service.Services.Abstract;

namespace Case.Service.Services.Concrete
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepositoryBase<Product> repository) : base(unitOfWork, repository)
        {
        }
    }
}
