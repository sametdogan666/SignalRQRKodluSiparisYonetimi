using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.ProductDto;
using SignalR.Dto.SocialMediaDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet("get-list-social-medias")]
        public IActionResult GetListSocialMedias()
        {
            var results = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.GetAll());

            return Ok(results);
        }

        [HttpPost("create-social-media")]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.Add(new SocialMedia()
            {
               Title = createSocialMediaDto.Title,
               Url = createSocialMediaDto.Url,
               Icon = createSocialMediaDto.Icon
            });

            return Ok("Sosyal Medya Bilgisi Eklendi");
        }

        [HttpDelete("delete-social-media/{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.GetById(id);

            _socialMediaService.Remove(value);

            return Ok("Sosyal Medya Bilgisi Silindi");
        }

        [HttpPut("update-social-media")]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialMediaService.Update(new SocialMedia()
            {
                Id = updateSocialMediaDto.Id,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
                Icon = updateSocialMediaDto.Icon
            });

            return Ok("Sosyal Medya Bilgisi Güncellendi");
        }

        [HttpGet("get-by-id-social-media/{id}")]
        public IActionResult GetByIdSocialMedia(int id)
        {
            var result = _socialMediaService.GetById(id);

            return Ok(result);
        }
    }
}
