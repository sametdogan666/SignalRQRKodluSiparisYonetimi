using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.Dto.BasketDto;
using SignalR.Dto.CategoryDto;
using SignalR.Dto.ProductDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;

        public BasketsController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet("get-basket-by-menu-table-number/{id}")]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            var results = _basketService.GetBasketByMenuTableNumber(id);
            
            return Ok(results);
        }

        [HttpGet("get-basket-list-by-menu-table-with-product-name/{id}")]
        public IActionResult GetBasketListByMenuTableWithProductName(int id)
        {
            var results = _mapper.Map<List<ResultBasketWithProductDto>>(_basketService.GetBasketListByMenuTableWithProductName(id));

            return Ok(results);
        }

        [HttpPost("create-basket")]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();

            _basketService.Add(new Basket()
            {
                ProductId = createBasketDto.ProductId,
                Count = 1,
                MenuTableId = 4,
                Price = context.Products.Where(x=>x.Id == createBasketDto.ProductId).Select(x=>x.Price).FirstOrDefault(),
                TotalPrice = 0
            });

            return Ok("Sepete Eklendi");
        }
    }
}
