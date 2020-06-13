using MS.AFORO255.Cross.RabbitMQ.RabbitMq.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Pay.RabbitMq.Events
{
    public class PaymentCreatedEvent : Event
    {
        public int id_operation { get; set; }
        public int id_invoice { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }

        public PaymentCreatedEvent(int id_operation, int id_invoice, decimal amount, DateTime date)
        {
            this.id_operation = id_operation;
            this.id_invoice = id_invoice;
            this.amount = amount;
            this.date = date;
        }
    }
}
