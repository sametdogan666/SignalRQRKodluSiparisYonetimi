using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("get-total-order-count")]
        public IActionResult GetTotalOrderCount()
        {
            return Ok(_orderService.GetTotalOrderCount());
        }

        [HttpGet("get-active-order-count")]
        public IActionResult GetActiveOrderCount()
        {
            return Ok(_orderService.GetActiveOrderCount());
        }

        [HttpGet("get-last-order-price")]
        public IActionResult GetLastOrderPrice()
        {
            return Ok(_orderService.GetLastOrderPrice());
        }
    }
}
