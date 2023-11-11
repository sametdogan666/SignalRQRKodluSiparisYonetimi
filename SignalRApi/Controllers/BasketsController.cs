using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("get-basket-by-menu-table-number/{id}")]
        public IActionResult GetBasketByMenuTableNumber(int id)
        {
            var results = _basketService.GetBasketByMenuTableNumber(id);
            
            return Ok(results);
        }
    }
}
