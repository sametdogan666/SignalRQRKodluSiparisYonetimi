using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.AboutDto;
using SignalR.Dto.MenuTableDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;

        public MenuTablesController(IMenuTableService menuTableService)
        {
            _menuTableService = menuTableService;
        }

        [HttpGet("get-menu-table-count")]
        public IActionResult GetMenuTableCount()
        {
            return Ok(_menuTableService.GetMenuTableCount());
        }

        [HttpGet("get-list-menu-tables")]
        public IActionResult GetListMenuTables()
        {
            var results = _menuTableService.GetAll();

            return Ok(results);
        }

        [HttpPost("create-menu-table")]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
        {
            MenuTable menuTable = new MenuTable()
            {
               Name = createMenuTableDto.Name,
               Status = false
            };

            _menuTableService.Add(menuTable);

            return Ok("Masa Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("delete-menu-table/{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var value = _menuTableService.GetById(id);

            _menuTableService.Remove(value);

            return Ok("Masa Başarılı Bir Şekilde Silindi");
        }

        [HttpPut("update-menu-table")]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
        {
            MenuTable menuTable= new MenuTable()
            {
                Id = updateMenuTableDto.Id,
                Name = updateMenuTableDto.Name,
                Status = updateMenuTableDto.Status
            };

            _menuTableService.Update(menuTable);

            return Ok("Masa Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("get-by-id-menu-table/{id}")]
        public IActionResult GetByIdMenuTable(int id)
        {
            var result = _menuTableService.GetById(id);

            return Ok(result);
        }
    }
}
