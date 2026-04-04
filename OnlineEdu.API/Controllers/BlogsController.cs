using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BlogDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IGenericService<Blog> blogService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = blogService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = blogService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            blogService.TDelete(id);
            return Ok("Blog field has been deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateBlogDto createBlogDto)
        {
            var newValue = mapper.Map<Blog>(createBlogDto);
            newValue.BlogDate = DateTime.Now;
            blogService.TCreate(newValue);
            return Ok("Blog field has been created");
        }

        [HttpPut]
        public IActionResult Update(UpdateBlogDto updateBlogDto)
        {
            var updatedValue = mapper.Map<Blog>(updateBlogDto);
            blogService.TUpdate(updatedValue);
            return Ok("Blog field has been updated");
        }
    }
}
