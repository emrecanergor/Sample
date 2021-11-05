using AutoMapper;
using Case.API.Controllers;
using Case.Domain.DTO.Product;
using Case.Service.Mapping;
using Case.Service.Services.Abstract;
using Case.Test.Fake;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Case.Test.Test
{
    public class ProductControllerTest
    {
        private readonly ProductsController _productController;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductControllerTest()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapModel());
            });
            _mapper = new Mapper(mapperConfig);
            _productService = new ProductServiceFake();
            _productController = new ProductsController(_productService, _mapper);
        }

        [Fact]
        public async void GetAll_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = await _productController.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public async void GetAll_WhenCalled_ReturnsGreaterThanZeroItems()
        {
            // Act
            var okResult = await _productController.GetAll() as OkObjectResult;

            // Assert
            var products = Assert.IsType<List<ProductDto>>(okResult.Value);
            Assert.True(products.Count() > 0, "The products were greater than zero");
        }

        [Fact]
        public async void GetById_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            int existId = 2;

            // Act
            var okResult = await _productController.GetById(existId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public async void GetById_WhenCalled_ReturnsNotFoundResult()
        {
            // Arrange
            int notExistId = 99;

            // Act
            var notFoundResult = await _productController.GetById(notExistId);

            // Assert 
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public async void Save_ProducPassed_ReturnsOkResult()
        {
            // Arrange
            var passOkItem = new ProductSaveDto()
            {
                Title = "Test Product",
                Description = "Test Product Desc",
                StockQuantity = 4,
                CategoryId = 3
            };

            // Act
            var okResult = await _productController.Save(passOkItem);

            // Assert
            Assert.IsType<CreatedResult>(okResult);
        }

        [Fact]
        public void Update_ProducPassed_ReturnsOkResult()
        {
            // Arrange
            var passOkItem = new ProductDto()
            {
                Id = 2,
                Title = "Test Product",
                Description = "Test Product Desc",
                StockQuantity = 4,
                CategoryId = 3
            };

            // Act
            var okResult = _productController.Update(passOkItem);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Update_NotExistProductIdPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var passMissingItem = new ProductDto()
            {
                Id = 100,
                CategoryId = 2,
                Description = "aa",
                Title = "bb",
                StockQuantity = 5
            };

            // Act
            var notFoundResult = _productController.Update(passMissingItem);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void Remove_ProducPassed_ReturnsOkResult()
        {
            // Arrange
            int existId = 2;

            // Act
            var okResult = _productController.Remove(existId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void Remove_NotExistProductIdPassed_ReturnsNotFoundResult()
        {
            // Arrange
            int notExistId = 100;

            // Act
            var notFoundResult = _productController.Remove(notExistId);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}
