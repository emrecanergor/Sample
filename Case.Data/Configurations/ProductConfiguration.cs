using Case.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Case.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired();

            builder.Property(x => x.StockQuantity).IsRequired();

            builder.ToTable("Products");

            builder.HasData(
                new Product { CategoryId = 1, Title = "Buzdolabı", Id = 1, Description = "NoFrost", StockQuantity = 5 },
                new Product { CategoryId = 2, Title = "Koltuk", Id = 2, Description = "Rahat", StockQuantity = 6 },
                new Product { CategoryId = 3, Title = "Kamera", Id = 3, Description = "150mp", StockQuantity = 7 },
                new Product { CategoryId = 4, Title = "Salıncak", Id = 4, Description = "200kg kapasiteli", StockQuantity = 8 }
                );
        }
    }
}
