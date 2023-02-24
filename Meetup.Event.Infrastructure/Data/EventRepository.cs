using Meetup.Event.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Meetup.Event.Infrastructure.Data
{
    public class EventRepository : IEventRepository
    {
        private DataContext context;
        public EventRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Domain.Entities.Event>> GetAllEvents() =>
            await context.Events.AsNoTracking().ToListAsync();

        public async Task<Domain.Entities.Event> GetSingleEvent(int id) =>
            await context.Events.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        public async Task<List<Domain.Entities.Event>> AddNewEvent(Domain.Entities.Event newEvent) {
            context.Events.Add(newEvent);
            await context.SaveChangesAsync();

            return await GetAllEvents();
        }

        public async Task<Domain.Entities.Event> EditEvent(Domain.Entities.Event newEvent) {
            var prevEvent = await context.Events.FirstOrDefaultAsync(e => e.Id == newEvent.Id);
            if (prevEvent is null) return null;

            prevEvent.Title = newEvent.Title;
            prevEvent.Description = newEvent.Description;
            prevEvent.DateTime = newEvent.DateTime;
            prevEvent.Venue = newEvent.Venue;
            prevEvent.OrganizerName = newEvent.OrganizerName;

            await context.SaveChangesAsync();

            return newEvent;
        }

        public async Task<List<Domain.Entities.Event>> DeleteEvent(int id)
        {
            var _event = await GetSingleEvent(id);
            if (_event is null) return null;

            context.Events.Remove(_event);
            await context.SaveChangesAsync();
            return await GetAllEvents();
        }
    }
}
