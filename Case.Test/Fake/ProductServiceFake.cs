using Case.Domain.DTO.Product;
using Case.Domain.Entity;
using Case.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Case.Test.Fake
{
    public class ProductServiceFake : IProductService
    {
        private readonly List<Product> _product;
        public ProductServiceFake()
        {
            _product = new List<Product> {
                new Product { CategoryId = 1, Title = "Buzdolabı", Id = 1, Description = "NoFrost", StockQuantity = 5 },
                new Product { CategoryId = 2, Title = "Koltuk", Id = 2, Description = "Rahat", StockQuantity = 6 },
                new Product { CategoryId = 3, Title = "Kamera", Id = 3, Description = "150mp", StockQuantity = 7 },
                new Product { CategoryId = 4, Title = "Salıncak", Id = 4, Description = "200kg kapasiteli", StockQuantity = 8 }
            };
        }

        public async Task<Product> AddAsync(Product entity)
        {
            _product.Add(entity);
            return entity;
        }

        public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            _product.AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return _product.ToList();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return _product.FirstOrDefault(s => s.Id == id);
        }

        public void Remove(Product entity)
        {
            _product.Remove(entity);
        } 

        public Product Update(Product entity)
        { 
            int index = _product.IndexOf(_product.FirstOrDefault(s => s.Id == entity.Id));
            if (index > -1)
            {
                _product[index] = entity;
                return entity;
            }
            return null;
        }

        public async Task<IEnumerable<Product>> Where(Expression<Func<Product, bool>> predicate)
        {
            var compiledPredicate = predicate.Compile();
            return _product.Where(compiledPredicate);
        }
    }
}
