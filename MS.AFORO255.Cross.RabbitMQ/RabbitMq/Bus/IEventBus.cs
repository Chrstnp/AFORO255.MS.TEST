using MS.AFORO255.Cross.RabbitMQ.RabbitMq.Commands;
using MS.AFORO255.Cross.RabbitMQ.RabbitMq.Events;
using System.Threading.Tasks;

namespace MS.AFORO255.Cross.RabbitMQ.RabbitMq.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}
