using System;

namespace Models
{
    public class Event
    {
        public Event() { }
        public Event(int id, string name)
        {
            this.Id = id;
            this.EventName = name;
        }
        public int Id { get; set; }
        public string EventName { get; set; }
    }
}
