using MediatR;

namespace MS.AFORO255.Cross.RabbitMQ.RabbitMq.Events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
