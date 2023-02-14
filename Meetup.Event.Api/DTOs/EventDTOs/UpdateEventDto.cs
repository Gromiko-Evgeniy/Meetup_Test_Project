namespace Meetup.Event.Api.DTOs.EventDTOs
{
    public class UpdateEventDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Venue { get; set; } = string.Empty;
    }
}
