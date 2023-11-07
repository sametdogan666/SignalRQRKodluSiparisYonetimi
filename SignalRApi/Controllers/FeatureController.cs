using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.DiscountDto;
using SignalR.Dto.FeatureDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper  _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet("get-list-features")]
        public IActionResult GetListFeatures()
        {
            var results = _mapper.Map<List<ResultFeatureDto>>(_featureService.GetAll());

            return Ok(results);
        }

        [HttpPost("create-feature")]
        public IActionResult CreateFeature(CreateFeatureDto createDiscountDto)
        {
            _featureService.Add(new Feature()
            {
                Title1 = createDiscountDto.Title1,
                Description1 = createDiscountDto.Description1,
                Title2 = createDiscountDto.Title2,
                Description2 = createDiscountDto.Description2,
                Title3 = createDiscountDto.Title3,
                Description3 = createDiscountDto.Description3
            });

            return Ok("Öne Çıkan Bilgisi Eklendi");
        }

        [HttpDelete("delete-feature/{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.GetById(id);

            _featureService.Remove(value);

            return Ok("Öne Çıkan Bilgisi Silindi");
        }

        [HttpPut("update-feature")]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _featureService.Update(new Feature()
            {
                Id = updateFeatureDto.Id,
                Title1 = updateFeatureDto.Title1,
                Description1 = updateFeatureDto.Description1,
                Title2 = updateFeatureDto.Title2,
                Description2 = updateFeatureDto.Description2,
                Title3 = updateFeatureDto.Title3,
                Description3 = updateFeatureDto.Description3
            });

            return Ok("Öne Çıkan Bilgisi Güncellendi");
        }

        [HttpGet("get-by-id-feature/{id}")]
        public IActionResult GetByIdFeature(int id)
        {
            var result = _featureService.GetById(id);

            return Ok(result);
        }
    }
}
