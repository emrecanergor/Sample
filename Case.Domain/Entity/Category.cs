using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Case.Domain.Entity
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
