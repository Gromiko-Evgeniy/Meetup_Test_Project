using AutoMapper;
using Meetup.Event.Domain.DTOs.EventDTOs;
using Meetup.Event.Application.Interfaces;
using Meetup.Common;

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

        public async Task<ResponseInfo<List<Domain.Entities.Event>>> GetAllEvents()
        {
            var events = await repository.GetAllEvents();
            return new ResponseInfo<List<Domain.Entities.Event>>(events, true, "all events"); ;
        }

        public async Task<ResponseInfo<Domain.Entities.Event>> GetSingleEvent(int id)
        {
            var _event = await repository.GetSingleEvent(id);
            if (_event is null) return new ResponseInfo<Domain.Entities.Event>(null, false, "event not found");
            
            return new ResponseInfo<Domain.Entities.Event>(_event, true, $"event with id {id}");
        }

        public async Task<ResponseInfo<List<Domain.Entities.Event>>> AddNewEvent(AddEventDto eventDto)
        {
            if(eventDto is null) return new ResponseInfo<List<Domain.Entities.Event>>(null, false, "wrong request data");
            var newEvent = mapper.Map<Domain.Entities.Event>(eventDto);

            var events = await repository.AddNewEvent(newEvent);

            return new ResponseInfo<List<Domain.Entities.Event>>(events, true, "all events");
        }

        public async Task<ResponseInfo<List<Domain.Entities.Event>>> DeleteEvent(int id)
        {
            var events = await repository.DeleteEvent(id);
            if (events is null) return new ResponseInfo<List<Domain.Entities.Event>>(null, false, "event not found");

            return new ResponseInfo<List<Domain.Entities.Event>>(events, true, "all events");
        }

        public async Task<ResponseInfo<Domain.Entities.Event>> EditEvent(UpdateEventDto eventDto)
        {
            if (eventDto == null) return new ResponseInfo<Domain.Entities.Event>(null, false, "wrong request data");
            var newEvent = mapper.Map<Domain.Entities.Event>(eventDto);
            
            var response = await repository.EditEvent(newEvent);
            if (response is null) return new ResponseInfo<Domain.Entities.Event>(null, false, "event not found");

            return new ResponseInfo<Domain.Entities.Event>(response, true, $"order with id {newEvent.Id}");
        }
    }
}