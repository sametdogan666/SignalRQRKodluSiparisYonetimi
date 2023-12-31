﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Abstract;
using SignalR.Dto.ContactDto;
using SignalR.Dto.DiscountDto;
using SignalR.Entities.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet("get-list-discounts")]
        public IActionResult GetListDiscounts()
        {
            var results = _mapper.Map<List<ResultDiscountDto>>(_discountService.GetAll());

            return Ok(results);
        }

        [HttpPost("create-discount")]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            _discountService.Add(new Discount()
            {
                Title = createDiscountDto.Title,
                Description = createDiscountDto.Description,
                Amount = createDiscountDto.Amount,
                ImageUrl = createDiscountDto.ImageUrl,
                Status = false
            });

            return Ok("İndirim Bilgisi Eklendi");
        }

        [HttpDelete("delete-discount/{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.GetById(id);

            _discountService.Remove(value);

            return Ok("İndirim Bilgisi Silindi");
        }

        [HttpPut("update-discount")]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.Update(new Discount()
            {
                Id = updateDiscountDto.Id,
                Title = updateDiscountDto.Title,
                Description = updateDiscountDto.Description,
                Amount = updateDiscountDto.Amount,
                ImageUrl = updateDiscountDto.ImageUrl,
                Status = false
            });

            return Ok("İndirim Bilgisi Güncellendi");
        }

        [HttpGet("get-by-id-discount/{id}")]
        public IActionResult GetByIdDiscount(int id)
        {
            var result = _discountService.GetById(id);

            return Ok(result);
        }

        [HttpGet("change-to-status-false/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
             _discountService.ChangeStatusToFalse(id);

            return Ok("İndirim Durumu Güncellendi");
        }

        [HttpGet("change-to-status-true/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.ChangeStatusToTrue(id);

            return Ok("İndirim Durumu Güncellendi");
        }

        [HttpGet("get-list-by-status-true")]
        public IActionResult GetListByStatusTrue()
        {
            var results = _mapper.Map<List<ResultDiscountDto>>(_discountService.GetListByStatusTrue());

            return Ok(results);
        }
    }
}
