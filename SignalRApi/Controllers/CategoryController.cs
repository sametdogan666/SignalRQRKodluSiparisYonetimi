using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.BookingDto;
using SignalR.Dto.CategoryDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("get-list-categories")]
        public IActionResult GetListCategories()
        {
            var results = _mapper.Map<List<ResultCategoryDto>>(_categoryService.GetAll());

            return Ok(results);
        }

        [HttpPost("create-category")]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryService.Add(new Category()
            {
                CategoryName = createCategoryDto.CategoryName,
                Status = true
            });

            return Ok("Kategori Eklendi");
        }

        [HttpDelete("delete-category/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.GetById(id);

            _categoryService.Remove(value);

            return Ok("Kategori Silindi");
        }

        [HttpPut("update-category")]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryService.Update(new Category()
            {
                Id = updateCategoryDto.Id,
                CategoryName = updateCategoryDto.CategoryName,
                Status = updateCategoryDto.Status
            });

            return Ok("Kategori Güncellendi");
        }

        [HttpGet("get-by-id-category/{id}")]
        public IActionResult GetByIdCategory(int id)
        {
            var result = _categoryService.GetById(id);

            return Ok(result);
        }

        [HttpGet("get-category-count")]
        public IActionResult GetCategoryCount()
        {
            return Ok(_categoryService.GetCategoryCount());
        }

        [HttpGet("get-active-category-count")]
        public IActionResult GetActiveCategoryCount()
        {
            return Ok(_categoryService.GetActiveCategoryCount());
        }

        [HttpGet("get-passive-category-count")]
        public IActionResult GetPassiveCategoryCount()
        {
            return Ok(_categoryService.GetPassiveCategoryCount());
        }
    }
}
