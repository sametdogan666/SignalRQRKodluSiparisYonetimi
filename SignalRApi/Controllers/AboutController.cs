using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.AboutDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet("get-list-abouts")]
        public IActionResult GetListAbouts()
        {
            var results = _aboutService.GetAll();

            return Ok(results);
        }

        [HttpPost("create-about")]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About()
            {
                Title = createAboutDto.Title,
                Description = createAboutDto.Description,
                ImageUrl = createAboutDto.ImageUrl
            };

            _aboutService.Add(about);

            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("delete-about/{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.GetById(id);

            _aboutService.Remove(value);

            return Ok("Hakkımda Alanı Başarılı Bir Şekilde Silindi");
        }

        [HttpPut("update-about")]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            About about = new About()
            {
                Id = updateAboutDto.Id,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description,
                ImageUrl = updateAboutDto.ImageUrl
            };

            _aboutService.Update(about);

            return Ok("Hakkımda Alanı Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("get-by-id-about/{id}")]
        public IActionResult GetByIdAbout(int id)
        {
            var result = _aboutService.GetById(id);

            return Ok(result);
        }
    }
}
