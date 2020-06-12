using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFORO255.MS.TEST.Invoice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.Invoice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IRepositoryInvoice _repositoryInvoice;

        public InvoiceController(IRepositoryInvoice repositoryInvoice)
        {
            _repositoryInvoice = repositoryInvoice;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositoryInvoice.GetAll());
        }

    }
}
