using AFORO255.MS.TEST.Transaction.Model;
using AFORO255.MS.TEST.Transaction.RabbitMQ.Events;
using AFORO255.MS.TEST.Transaction.Repository;
using AFORO255.MS.TEST.Transaction.Service;
using MS.AFORO255.Cross.RabbitMQ.RabbitMq.Bus;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Transaction.RabbitMQ.EventHandlers
{
    public class TransactionEventHandler : IEventHandler<TransactionCreatedEvent>
    {
        private readonly IServiceTransaction _serviceTransaction;

        public TransactionEventHandler(IServiceTransaction serviceTransaction)
        {
            _serviceTransaction = serviceTransaction;
        }
        public Task Handle(TransactionCreatedEvent @event)
        {
            _serviceTransaction.Add(new PayTransaction()
            {
                id_transaccion = @event.id_operation,
                id_invoice = @event.id_invoice,
                amount = @event.amount,
                date = @event.date
            });
            return Task.CompletedTask;
        }
    }
}
