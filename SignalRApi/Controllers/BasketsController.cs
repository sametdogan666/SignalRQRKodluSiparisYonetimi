using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.BasketDto;
using SignalR.Dto.ProductDto;

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
    }
}
