using AutoMapper;
using Meetup.Event.Api.DTOs.EventDTOs;
using Meetup.Event.Api.Entities;
using Meetup.Event.Api.Interfaces;

namespace Meetup.Event.Api.Services
{
    public class EventService : IEventService
    {
        private IMapper mapper;
        private IEventRepository repository;

        public EventService(IMapper mapper, IEventRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<ResponseInfo<List<GetEventDTO>>> GetAllEvents()
        {
            var events = await repository.GetAllEvents();
            var eventDTOs = events.Select(p => mapper.Map<GetEventDTO>(p)).ToList();
            return new ResponseInfo<List<GetEventDTO>>(eventDTOs, true, "all events"); ;
        }

        public async Task<ResponseInfo<GetEventDTO>> GetSingleEvent(int id)
        {
            var _event = await repository.GetSingleEvent(id);
            if (_event is null) return new ResponseInfo<GetEventDTO>(null, false, "event not found");
            
            return new ResponseInfo<GetEventDTO>(mapper.Map<GetEventDTO>(_event), true, $"event with id {id}");
        }

        public async Task<ResponseInfo<List<GetEventDTO>>> AddNewEvent(AddEventDto eventDto)
        {
            var newEvent = mapper.Map<Entities.Event>(eventDto);

            var response = await repository.AddNewEvent(newEvent);
            if (response is null) return new ResponseInfo<List<GetEventDTO>>(null, false, "wrong request data");

            var eventDTOs = response.Select(p => mapper.Map<GetEventDTO>(p)).ToList();
            return new ResponseInfo<List<GetEventDTO>>(eventDTOs, true, "all events");
        }

        public async Task<ResponseInfo<List<GetEventDTO>>> DeleteEvent(int id)
        {
            var response = await repository.DeleteEvent(id);
            if (response is null) return new ResponseInfo<List<GetEventDTO>>(null, false, "event not found");

                        var eventDTOs = response.Select(p => mapper.Map<GetEventDTO>(p)).ToList();
            return new ResponseInfo<List<GetEventDTO>>(eventDTOs, true, "all events");
        }

        public async Task<ResponseInfo<GetEventDTO>> EditEvent(UpdateEventDto eventDto)
        {
            if (eventDto == null) return new ResponseInfo<GetEventDTO>(null, false, "wrong request data");
            var newEvent = mapper.Map<Entities.Event>(eventDto);
            
            var response = await repository.EditEvent(newEvent);
            if (response is null) return new ResponseInfo<GetEventDTO>(null, false, "event not found");

            return new ResponseInfo<GetEventDTO>(mapper.Map<GetEventDTO>(newEvent), true, $"order with id {newEvent.Id}");
        }
    }
}