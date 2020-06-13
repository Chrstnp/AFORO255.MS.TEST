using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AFORO255.MS.TEST.Transaction.Dto;
using AFORO255.MS.TEST.Transaction.Model;
using AFORO255.MS.TEST.Transaction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.Transaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IServiceTransaction _services;

        public TransactionController(IServiceTransaction services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _services.GetAll());
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] PayTransaction request)
        {
            await _services.Add(request);
            return Ok();
        }

        [HttpGet("{invoiceId}")]
        public async Task<IActionResult> Get(int invoiceId)
        {
            var result = await _services.GetAll();
            IEnumerable<PayTransactionResponse> model = result.Where(x => x.id_invoice == invoiceId).ToList();

            return Ok(model);
        }
    }
}
