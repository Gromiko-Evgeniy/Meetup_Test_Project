using Meetup.Event.Api.Entities;

namespace Meetup.Event.Api.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Entities.Event>> GetAllEvents();
        Task<Entities.Event> GetSingleEvent(int id);
        Task<List<Entities.Event>> AddNewEvent(Entities.Event newEvent);
        Task<Entities.Event> EditEvent(Entities.Event newEvent);
        Task<List<Entities.Event>> DeleteEvent(int id);
    }
}
