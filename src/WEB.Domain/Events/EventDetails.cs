using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Domain.Events
{
    internal class EventDetails
    {
        public EventDetails(int capacity, string description)
        {
            Capacity = capacity;
            Description = description;
        }
        public Guid EventId { get; } = Guid.Empty;
        public int Capacity { get; private set; }
        public string Description { get; private set; }
    }
}
