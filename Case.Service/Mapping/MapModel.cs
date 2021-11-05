using AutoMapper;
using Case.Domain.DTO.Product;
using Case.Domain.Entity;

namespace Case.Service.Mapping
{
    public class MapModel : Profile
    {
        public MapModel()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductSaveDto>().ReverseMap();
        }
    }
}
