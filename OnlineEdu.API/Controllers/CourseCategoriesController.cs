using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseCategoryDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController(ICourseCategoryService courseCategoryService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = courseCategoryService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = courseCategoryService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            courseCategoryService.TDelete(id);
            return Ok("Course category has been deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateCourseCategoryDto createCourseCategoryDto)
        {
            var newValue = mapper.Map<CourseCategory>(createCourseCategoryDto);
            courseCategoryService.TCreate(newValue);
            return Ok("Course category has been created");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            var updatedValue = mapper.Map<CourseCategory>(updateCourseCategoryDto);
            courseCategoryService.TUpdate(updatedValue);
            return Ok("Course category has been updated");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            courseCategoryService.TShowOnHome(id);
            return Ok("Course category has been shown on home page");
        }

        [HttpGet("HideOnHome/{id}")]
        public IActionResult HideOnHome(int id)
        {
            courseCategoryService.THideOnHome(id);
            return Ok("Course category has been hidden on home page");
        }
    }
}
