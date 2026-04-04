using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDTOs;
using OnlineEdu.DTO.DTOs.ContactDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IGenericService<Contact> contactService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = contactService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = contactService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            contactService.TDelete(id);
            return Ok("Contact field has been deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateContactDto createContactDto)
        {
            var newValue = mapper.Map<Contact>(createContactDto);
            contactService.TCreate(newValue);
            return Ok("Contact field has been created");
        }

        [HttpPut]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var updatedValue = mapper.Map<Contact>(updateContactDto);
            contactService.TUpdate(updatedValue);
            return Ok("Contact field has been updated");
        }
    }
}
