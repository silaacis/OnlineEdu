using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BannerDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> bannerService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = bannerService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = bannerService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bannerService.TDelete(id);
            return Ok("Banner field has been deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateBannerDto createBannerDto)
        {
            var newValue = mapper.Map<Banner>(createBannerDto);
            bannerService.TCreate(newValue);
            return Ok("Banner field has been created");
        }

        [HttpPut]
        public IActionResult Update(UpdateBannerDto updateBannerDto)
        {
            var updatedValue = mapper.Map<Banner>(updateBannerDto);
            bannerService.TUpdate(updatedValue);
            return Ok("Banner field has been updated");
        }
    }
}
