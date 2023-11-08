using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.FeatureDto;
using SignalR.Dto.ProductDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("get-list-products")]
        public IActionResult GetListProducts()
        {
            var results = _mapper.Map<List<ResultProductDto>>(_productService.GetAll());

            return Ok(results);
        }

        [HttpGet("get-list-products-with-category")]
        public IActionResult GetListProductsWithCategory()
        {
            var results = _mapper.Map<List<ResultProductWithCategoryDto>>(_productService.GetProductsWithCategory());

            return Ok(results);
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.Add(new Product()
            {
                ProductName = createProductDto.ProductName,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                ImageUrl = createProductDto.ImageUrl,
                CategoryId = createProductDto.CategoryId,
                Status = true
            });

            return Ok("Ürün Bilgisi Eklendi");
        }

        [HttpDelete("delete-product/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.GetById(id);

            _productService.Remove(value);

            return Ok("Ürün Bilgisi Silindi");
        }

        [HttpPut("update-product")]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.Update(new Product()
            {
                Id = updateProductDto.Id,
                ProductName = updateProductDto.ProductName,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                ImageUrl = updateProductDto.ImageUrl,
                CategoryId = updateProductDto.CategoryId,
                Status = updateProductDto.Status
            });

            return Ok("Ürün Bilgisi Güncellendi");
        }

        [HttpGet("get-by-id-product/{id}")]
        public IActionResult GetByIdProduct(int id)
        {
            var result = _productService.GetById(id);

            return Ok(result);
        }

        [HttpGet("get-product-count")]
        public IActionResult GetProductCount()
        {
            return Ok(_productService.GetProductCount());
        }

        [HttpGet("get-product-count-by-hamburger")]
        public IActionResult GetProductCountByCategoryNameHamburger()
        {
            return Ok(_productService.GetProductCountByCategoryNameHamburger());
        }

        [HttpGet("get-product-count-by-drink")]
        public IActionResult GetProductCountByCategoryNameDrink()
        {
            return Ok(_productService.GetProductCountByCategoryNameDrink());
        }
    }
}
