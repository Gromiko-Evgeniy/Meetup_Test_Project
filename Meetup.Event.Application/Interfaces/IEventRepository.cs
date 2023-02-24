namespace Meetup.Event.Application.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Domain.Entities.Event>> GetAllEvents();
        Task<Domain.Entities.Event> GetSingleEvent(int id);
        Task<List<Domain.Entities.Event>> AddNewEvent(Domain.Entities.Event newEvent);
        Task<Domain.Entities.Event> EditEvent(Domain.Entities.Event newEvent);
        Task<List<Domain.Entities.Event>> DeleteEvent(int id);
    }
} 

