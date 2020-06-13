using AFORO255.MS.TEST.Pay.Dto;
using AFORO255.MS.TEST.Pay.Model;
using AFORO255.MS.TEST.Pay.RabbitMq.Commands;
using AFORO255.MS.TEST.Pay.Repository;
using Microsoft.AspNetCore.Mvc;
using MS.AFORO255.Cross.RabbitMQ.RabbitMq.Bus;
using System;
using System.Transactions;

namespace AFORO255.MS.TEST.Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IRepositoryOperation _repositoryOperation;
        private readonly IEventBus _bus;

        public OperationController(IRepositoryOperation repositoryOperation, IEventBus bus)
        {
            _repositoryOperation = repositoryOperation;
            _bus = bus;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositoryOperation.GetAll());
        }

        [HttpPost]
        public IActionResult PostPay(PayTransaction payTransaction)
        {
            Operation operation = new Operation()
            {
                id_invoice = payTransaction.IdInvoice,
                amount = payTransaction.Amount,
                date = DateTime.Now
            };
            operation = _repositoryOperation.RegisterPayment(operation);

            var createCmmand = new PaymentCreateCommand(
                id_operation: operation.id_operation,
                id_invoice: operation.id_invoice,
                amount: operation.amount,
                date: operation.date
                );
            _bus.SendCommand(createCmmand);

            var transactionCommand = new TransactionCreateCommand(
                id_operation: operation.id_operation,
                id_invoice: operation.id_invoice,
                amount: operation.amount,
                date: operation.date
                );
            _bus.SendCommand(transactionCommand);

            return Ok(operation);
        }

    }
}
