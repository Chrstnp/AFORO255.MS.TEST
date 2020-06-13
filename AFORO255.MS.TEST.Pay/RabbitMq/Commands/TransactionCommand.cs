using MS.AFORO255.Cross.RabbitMQ.RabbitMq.Commands;
using System;

namespace AFORO255.MS.TEST.Pay.RabbitMq.Commands
{
    public class TransactionCommand : Command
    {
        public int id_operation { get; set; }
        public int id_invoice { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }
    }
}
