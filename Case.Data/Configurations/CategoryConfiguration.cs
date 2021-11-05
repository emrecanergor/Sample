using Case.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Case.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(100);

            builder.ToTable("Categories");


            builder.HasData(
                new Category { CategoryName = "Beyaz Eşya", Id = 1 },
                new Category { CategoryName = "Ev Eşyası", Id = 2 },
                new Category { CategoryName = "Teknoloji", Id = 3 },
                new Category { CategoryName = "Bahçe", Id = 4 }
                );
        }
    }
}
