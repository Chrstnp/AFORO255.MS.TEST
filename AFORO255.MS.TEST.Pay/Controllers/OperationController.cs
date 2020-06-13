using AFORO255.MS.TEST.Pay.Dto;
using AFORO255.MS.TEST.Pay.Model;
using AFORO255.MS.TEST.Pay.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AFORO255.MS.TEST.Pay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IRepositoryOperation _repositoryOperation;

        public OperationController(IRepositoryOperation repositoryOperation)
        {
            _repositoryOperation = repositoryOperation;
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
            return Ok(operation);
        }

    }
}
