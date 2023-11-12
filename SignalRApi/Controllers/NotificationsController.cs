using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.NotificationDto;
using SignalR.Entities.Entities;

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

        [HttpPost("create-notification")]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            _notificationService.Add(new Notification()
            {
                Description = createNotificationDto.Description,
                Icon = createNotificationDto.Icon,
                Type = createNotificationDto.Type,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = false
            });

            return Ok("Bildirim Eklendi");
        }

        [HttpDelete("delete-notification/{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var result = _notificationService.GetById(id);
            _notificationService.Remove(result);

            return Ok("Bildirim Silindi");
        }

        [HttpGet("get-by-id-notification/{id}")]
        public IActionResult GetByIdNotification(int id)
        {
            var result = _notificationService.GetById(id);

            return Ok(result);
        }

        [HttpPut("update-notification")]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            _notificationService.Update(new Notification()
            {
                Id = updateNotificationDto.Id,
                Description = updateNotificationDto.Description,
                Icon = updateNotificationDto.Icon,
                Type = updateNotificationDto.Type,
                Date = updateNotificationDto.Date,
                Status = updateNotificationDto.Status
            });

            return Ok("Bildirim Güncellendi");
        }

        [HttpGet("notification-change-to-status-true/{id}")]
        public IActionResult NotificationChangeToStatusTrue(int id)
        {
            _notificationService.NotificationChangeToStatusTrue(id);

            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("notification-change-to-status-false/{id}")]
        public IActionResult NotificationChangeToStatusFalse(int id)
        {
            _notificationService.NotificationChangeToStatusFalse(id);

            return Ok("Güncelleme Yapıldı");
        }
    }
}
