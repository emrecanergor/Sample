using Case.Data.Repositories.Abstract;
using Case.Data.Repositories.Concrete;
using System.Threading.Tasks;

namespace Case.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private ProductRepository _productRepository; 

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context); 

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
