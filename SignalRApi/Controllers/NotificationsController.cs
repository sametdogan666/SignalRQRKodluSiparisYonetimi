using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("get-notifications-list")]
        public IActionResult GetNotificationsList()
        {
            return Ok(_notificationService.GetAll());
        }
       
        [HttpGet("get-notifications-count-by-status-false")]
        public IActionResult GetNotificationCountByStatusFalse()
        {
            return Ok(_notificationService.GetNotificationCountByStatusFalse());
        }

        [HttpGet("get-all-notification-by-false")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.GetAllNotificationByFalse());
        }
    }
}
