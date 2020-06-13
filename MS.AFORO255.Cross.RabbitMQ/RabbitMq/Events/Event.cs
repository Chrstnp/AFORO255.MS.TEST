using System;

namespace MS.AFORO255.Cross.RabbitMQ.RabbitMq.Events
{
    public abstract class Event
    {
        public DateTime Timestamp { get; protected set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
