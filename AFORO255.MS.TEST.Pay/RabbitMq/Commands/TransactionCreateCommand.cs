using System;

namespace AFORO255.MS.TEST.Pay.RabbitMq.Commands
{
    public class TransactionCreateCommand : TransactionCommand
    {
        public TransactionCreateCommand(int id_operation, int id_invoice, decimal amount, DateTime date)
        {
            this.id_operation = id_operation;
            this.id_invoice = id_invoice;
            this.amount = amount;
            this.date = date;
        }
    }
}
