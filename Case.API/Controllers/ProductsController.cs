using AutoMapper;
using Case.Domain.DTO.Product;
using Case.Domain.Entity;
using Case.Service.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Case.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product != null)
            {
                return Ok(_mapper.Map<ProductDto>(product));
            }
            return NotFound();

        }


        [HttpPost]
        public async Task<IActionResult> Save(ProductSaveDto productDto)
        {
            var newproduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));

            return Created(string.Empty, _mapper.Map<ProductDto>(newproduct));
        }

        [HttpPut]
        public IActionResult Update(ProductDto productDto)
        {
            var product = _productService.Update(_mapper.Map<Product>(productDto));
            if (product != null)
            {
                return Ok(productDto);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            if (product != null)
            {
                _productService.Remove(product);
                return Ok(product);
            }

            return NotFound(); 
        }
    }
}
