using System;
using System.ComponentModel.DataAnnotations;

namespace Case.Domain.DTO.Product
{
    public class ProductSaveDto
    { 
        [Required(ErrorMessage = "{0} alanı gereklidir")]
        [MaxLength(200, ErrorMessage = "{0} 200 karakterden fazla olamaz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "{0} alanı 0'dan büyük bir değer olmalıdır.")]
        public int StockQuantity { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "{0} alanı 0'dan büyük bir değer olmalıdır.")]
        public int CategoryId { get; set; }
    }
}
