using Meetup.Event.Domain.DTOs.EventDTOs;
using Meetup.Common;

namespace Meetup.Event.Application.Interfaces
{
    public interface IEventService
    {
        Task<ResponseInfo<List<Domain.Entities.Event>>> GetAllEvents();
        Task<ResponseInfo<Domain.Entities.Event>> GetSingleEvent(int id);
        Task<ResponseInfo<List<Domain.Entities.Event>>> AddNewEvent(AddEventDto data);
        Task<ResponseInfo<Domain.Entities.Event>> EditEvent(UpdateEventDto data);
        Task<ResponseInfo<List<Domain.Entities.Event>>> DeleteEvent(int id);
    }
}
