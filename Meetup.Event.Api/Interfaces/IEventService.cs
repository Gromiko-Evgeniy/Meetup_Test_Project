using Meetup.Event.Api.DTOs.EventDTOs;
using Meetup.Event.Api.Entities;

namespace Meetup.Event.Api.Interfaces
{
    public interface IEventService
    {
        Task<ResponseInfo<List<GetEventDTO>>> GetAllEvents();
        Task<ResponseInfo<GetEventDTO>> GetSingleEvent(int id);
        Task<ResponseInfo<List<GetEventDTO>>> AddNewEvent(AddEventDto data);
        Task<ResponseInfo<GetEventDTO>> EditEvent(UpdateEventDto data);
        Task<ResponseInfo<List<GetEventDTO>>> DeleteEvent(int id);
    }
}
