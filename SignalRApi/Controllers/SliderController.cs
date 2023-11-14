using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.DiscountDto;
using SignalR.Dto.SliderDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(IMapper mapper, ISliderService sliderService)
        {
            _mapper = mapper;
            _sliderService = sliderService;
        }

        [HttpGet("get-list-sliders")]
        public IActionResult GetListSliders()
        {
            var results = _mapper.Map<List<ResultSliderDto>>(_sliderService.GetAll());

            return Ok(results);
        }

        [HttpPost("create-slider")]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            _sliderService.Add(new Slider()
            {
                Title1 = createSliderDto.Title1,
                Description1 = createSliderDto.Description1,
                Title2 = createSliderDto.Title2,
                Description2 = createSliderDto.Description2,
                Title3 = createSliderDto.Title3,
                Description3 = createSliderDto.Description3
            });

            return Ok("Öne Çıkan Bilgisi Eklendi");
        }

        [HttpDelete("delete-slider/{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.GetById(id);

            _sliderService.Remove(value);

            return Ok("Öne Çıkan Bilgisi Silindi");
        }

        [HttpPut("update-slider")]
        public IActionResult UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            _sliderService.Update(new Slider()
            {
                Id = updateSliderDto.Id,
                Title1 = updateSliderDto.Title1,
                Description1 = updateSliderDto.Description1,
                Title2 = updateSliderDto.Title2,
                Description2 = updateSliderDto.Description2,
                Title3 = updateSliderDto.Title3,
                Description3 = updateSliderDto.Description3
            });

            return Ok("Öne Çıkan Bilgisi Güncellendi");
        }

        [HttpGet("get-by-id-slider/{id}")]
        public IActionResult GetByIdSlider(int id)
        {
            var result = _sliderService.GetById(id);

            return Ok(result);
        }
    }
}
