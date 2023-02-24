namespace Meetup.Event.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task SeedData(DataContext context)
        {

            if (!context.Events.Any()) {
                var firstMeetup = new Domain.Entities.Event()
                {
                    Title = "meetup 1",
                    Description = "some description 1",
                    DateTime = new DateTime(2023, 2, 20, 18, 30, 0),
                    Venue = "online meetup",
                    OrganizerName = "Vasily"
                };
                var secondMeetup = new Domain.Entities.Event()
                {
                    Title = "meetup 2",
                    Description = "some description 2",
                    DateTime = new DateTime(2023, 2, 25, 12, 15, 0),
                    Venue = "online meetup",
                    OrganizerName = "Ivan"
                };
                var thirdMeetup = new Domain.Entities.Event()
                {
                    Title = "meetup 3",
                    Description = "some description 3",
                    DateTime = new DateTime(2023, 3, 1, 22, 0, 0),
                    Venue = "online meetup",
                    OrganizerName = "Max"
                };

                context.Events.AddRange(new Domain.Entities.Event[] { firstMeetup, secondMeetup, thirdMeetup });
            }
            
            await context.SaveChangesAsync();
        }
    }
}
