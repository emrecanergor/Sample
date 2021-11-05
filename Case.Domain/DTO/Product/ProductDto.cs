namespace Case.Domain.DTO.Product
{
    public class ProductDto
    {
        public int Id { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; } 
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}
