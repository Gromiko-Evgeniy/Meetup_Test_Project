using Meetup.Event.Domain.DTOs.EventDTOs;
using Meetup.Event.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meetup.Event.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllEvents() =>
            Ok(await eventService.GetAllEvents());


        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetSingleEvent(int id) =>
            Ok(await eventService.GetSingleEvent(id));


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddEvent(AddEventDto Event) =>
            Ok(await eventService.AddNewEvent(Event));


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateEvent(UpdateEventDto newEvent) =>
            Ok(await eventService.EditEvent(newEvent));


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEvent(int id) => 
            Ok(await eventService.DeleteEvent(id));
    }
}
