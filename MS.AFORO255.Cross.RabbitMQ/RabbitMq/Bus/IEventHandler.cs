using MS.AFORO255.Cross.RabbitMQ.RabbitMq.Events;
using System.Threading.Tasks;

namespace MS.AFORO255.Cross.RabbitMQ.RabbitMq.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
         where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
