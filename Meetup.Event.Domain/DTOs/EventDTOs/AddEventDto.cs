namespace Meetup.Event.Domain.DTOs.EventDTOs
{
    public class AddEventDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string OrganizerName { get; set; } = string.Empty;

    }
}
