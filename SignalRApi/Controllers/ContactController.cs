using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.CategoryDto;
using SignalR.Dto.ContactDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet("get-list-contacts")]
        public IActionResult GetListContacts()
        {
            var results = _mapper.Map<List<ResultContactDto>>(_contactService.GetAll());

            return Ok(results);
        }

        [HttpPost("create-contact")]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.Add(new Contact()
            {
                Email = createContactDto.Email,
                PhoneNumber = createContactDto.PhoneNumber,
                Location = createContactDto.Location,
                FooterDescription = createContactDto.FooterDescription
            });

            return Ok("İletişim Bilgisi Eklendi");
        }

        [HttpDelete("delete-contact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.GetById(id);

            _contactService.Remove(value);

            return Ok("İletişim Bilgisi Silindi");
        }

        [HttpPut("update-contact")]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.Update(new Contact()
            {
                Id = updateContactDto.Id,
                Email = updateContactDto.Email,
                PhoneNumber = updateContactDto.PhoneNumber,
                Location = updateContactDto.Location,
                FooterDescription = updateContactDto.FooterDescription
            });

            return Ok("İletişim Bilgisi Güncellendi");
        }

        [HttpGet("get-by-id-contact/{id}")]
        public IActionResult GetByIdContact(int id)
        {
            var result = _contactService.GetById(id);

            return Ok(result);
        }
    }
}
