using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.ContactDTOs;
using OnlineEdu.DTO.DTOs.CourseDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService courseService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = courseService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = courseService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            courseService.TDelete(id);
            return Ok("Course has been deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateCourseDto createCourseDto)
        {
            var newValue = mapper.Map<Course>(createCourseDto);
            courseService.TCreate(newValue);
            return Ok("Course has been created");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseDto updateCourseDto)
        {
            var updatedValue = mapper.Map<Course>(updateCourseDto);
            courseService.TUpdate(updatedValue);
            return Ok("Course has been updated");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            courseService.TShowOnHome(id);
            return Ok("Course has been shown on home page");
        }

        [HttpGet("HideOnHome/{id}")]
        public IActionResult HideOnHome(int id)
        {
            courseService.THideOnHome(id);
            return Ok("Course has been hidden on home page");
        }

        [HttpGet("GetActiveCourses")]
        public IActionResult GetActiveCourses()
        {
            var values = courseService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }
    }
}
