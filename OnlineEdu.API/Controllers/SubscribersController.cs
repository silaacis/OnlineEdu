using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.MessageDTOs;
using OnlineEdu.DTO.DTOs.SubscriberDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(IGenericService<Subscriber> subscriberService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = subscriberService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = subscriberService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            subscriberService.TDelete(id);
            return Ok("Subscriber has been deleted");
        }

        [HttpPost]
        public IActionResult Create(CreateSubscriberDto createSubscriberDto)
        {
            var newValue = mapper.Map<Subscriber>(createSubscriberDto);
            subscriberService.TCreate(newValue);
            return Ok("Subscriber has been created");
        }

        [HttpPut]
        public IActionResult Update(UpdateSubscriberDto updateSubscriberDto )
        {
            var updatedValue = mapper.Map<Subscriber>(updateSubscriberDto);
            subscriberService.TUpdate(updatedValue);
            return Ok("Subscriber has been updated");
        }
    }
}
