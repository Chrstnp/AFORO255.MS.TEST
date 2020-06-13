using AFORO255.MS.TEST.Invoice.RabbitMQ.Events;
using AFORO255.MS.TEST.Invoice.Repository;
using MS.AFORO255.Cross.RabbitMQ.RabbitMq.Bus;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Invoice.RabbitMQ.EventHandlers
{
    public class PaymentEventHandler : IEventHandler<PaymentCreatedEvent>
    {
        private readonly IRepositoryInvoice _repositoryInvoice;

        public PaymentEventHandler(IRepositoryInvoice repositoryInvoice)
        {
            _repositoryInvoice = repositoryInvoice;
        }

        public Task Handle(PaymentCreatedEvent @event)
        {
            _repositoryInvoice.Pay(@event.id_invoice);
            return Task.CompletedTask;
        }
    }
}
