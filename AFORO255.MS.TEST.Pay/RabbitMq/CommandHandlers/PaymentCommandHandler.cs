using AFORO255.MS.TEST.Pay.RabbitMq.Commands;
using AFORO255.MS.TEST.Pay.RabbitMq.Events;
using MediatR;
using MS.AFORO255.Cross.RabbitMQ.RabbitMq.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Pay.RabbitMq.CommandHandlers
{
    public class PaymentCommandHandler : IRequestHandler<PaymentCreateCommand, bool>
    {
        private readonly IEventBus _bus;

        public PaymentCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(PaymentCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new PaymentCreatedEvent(
                request.id_operation,
                request.id_invoice,
                request.amount,
                request.date
                ));
            return Task.FromResult(true);
        }
    }
}
