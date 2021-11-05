using System.ComponentModel.DataAnnotations;

namespace Case.Domain.DTO.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
