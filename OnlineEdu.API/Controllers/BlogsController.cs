using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BlogDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IMapper mapper, IBlogService blogService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = blogService.TGetBlogsWithCategories();
            var blogs = mapper.Map<List<ResultBlogDto>>(values);
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
