using WEB.Domain.Venue;

namespace WEB.Domain.Events
{
    public record EventId(Guid Value);

    public class Event
    {
        private Event()
        {   
            
        }

        public Event(EventId id, VenueId venueId, string name, DateTime eventDate, EventDetails eventDetails)
        {
            Id = id;
            VenueId = venueId;
            Name = name;
            EventDate = eventDate;
            Details = eventDetails;
        }

        public EventId Id { get; private set; }
        public VenueId VenueId { get; private set; }
        public string Name { get; private set; }
        public DateTime EventDate { get; private set; }
        public EventDetails Details { get; private set; }
    }
}