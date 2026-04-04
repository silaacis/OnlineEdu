using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.BlogCategoryDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController(IGenericService<BlogCategory> blogCategoryService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = blogCategoryService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = blogCategoryService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            blogCategoryService.TDelete(id);
            return Ok("Blog field has been deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateBlogCategoryDto createBlogCategoryDto)
        {
            var newValue = mapper.Map<BlogCategory>(createBlogCategoryDto);
            blogCategoryService.TCreate(newValue);
            return Ok("Blog category has been created");
        }

        [HttpPut]
        public IActionResult Update(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            var updatedValue = mapper.Map<BlogCategory>(updateBlogCategoryDto);
            blogCategoryService.TUpdate(updatedValue);
            return Ok("Blog category has been updated");
        }
    }
}
