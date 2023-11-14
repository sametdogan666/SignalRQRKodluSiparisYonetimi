using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.CategoryDto;
using SignalR.Dto.MessageDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessagesController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet("get-list-messages")]
        public IActionResult GetListCategories()
        {
            var results = _mapper.Map<List<ResultMessageDto>>(_messageService.GetAll());

            return Ok(results);
        }

        [HttpPost("create-message")]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            _messageService.Add(new Message()
            {
                FullName = createMessageDto.FullName,
                Email = createMessageDto.Email,
                PhoneNumber = createMessageDto.PhoneNumber,
                Subject = createMessageDto.Subject,
                MessageContent = createMessageDto.MessageContent,
                Status = false,
                SendDate = DateTime.Now
            });

            return Ok("Mesaj Başarılı Bir Şekilde Gönderildi");
        }

        [HttpDelete("delete-message/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.GetById(id);

            _messageService.Remove(value);

            return Ok("Mesaj Silindi");
        }

        [HttpPut("update-message")]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            _messageService.Update(new Message()
            {
                Id = updateMessageDto.Id,
                FullName = updateMessageDto.FullName,
                Email = updateMessageDto.Email,
                PhoneNumber = updateMessageDto.PhoneNumber,
                Subject = updateMessageDto.Subject,
                MessageContent = updateMessageDto.MessageContent,
                Status = false,
                SendDate = updateMessageDto.SendDate
            });

            return Ok("Mesaj Güncellendi");
        }

        [HttpGet("get-by-id-message/{id}")]
        public IActionResult GetByIdMessage(int id)
        {
            var result = _messageService.GetById(id);

            return Ok(result);
        }
    }
}
