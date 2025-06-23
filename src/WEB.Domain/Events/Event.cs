using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Domain.Events
{
    internal class Event
    {
        public Event(Guid id, Guid venueId, string name, DateTime eventDate, EventDetails eventDetails)
        {
            Id = id;
            VenueId = venueId;
            Name = name;
            EventDate = eventDate;
            Details = eventDetails;
        }
        public Guid Id { get; private set; }
        public Guid VenueId { get; private set; }
        public string Name { get; private set; }
        public DateTime EventDate { get; private set; }
        public EventDetails Details { get; private set; }
    }
}
