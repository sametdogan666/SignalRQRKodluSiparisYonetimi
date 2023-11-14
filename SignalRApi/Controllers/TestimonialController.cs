using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.SocialMediaDto;
using SignalR.Dto.TestimonialDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet("get-list-testimonials")]
        public IActionResult GetListTestimonials()
        {
            var results = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.GetAll());

            return Ok(results);
        }

        [HttpPost("create-testimonial")]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            _testimonialService.Add(new Testimonial()
            {
                FullName = createTestimonialDto.FullName,
                Title = createTestimonialDto.Title,
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl,
                Status = true
            });

            return Ok("Müşteri Yorum Bilgisi Eklendi");
        }

        [HttpDelete("delete-testimonial/{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.GetById(id);

            _testimonialService.Remove(value);

            return Ok("Müşteri Yorum Bilgisi Silindi");
        }

        [HttpPut("update-testimonial")]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.Update(new Testimonial()
            {
                Id = updateTestimonialDto.Id,
                FullName = updateTestimonialDto.FullName,
                Title = updateTestimonialDto.Title,
                Comment = updateTestimonialDto.Comment,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Status = true
            });

            return Ok("Müşteri Yorum Bilgisi Güncellendi");
        }

        [HttpGet("get-by-id-testimonial/{id}")]
        public IActionResult GetByIdTestimonial(int id)
        {
            var result = _testimonialService.GetById(id);

            return Ok(result);
        }
    }
}
