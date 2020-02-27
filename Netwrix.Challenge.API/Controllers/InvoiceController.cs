
namespace Netwrix.Challenge.API.Controllers {

    using System.Threading.Tasks;
    using Business.Models;
    using Microsoft.AspNetCore.Mvc;
    using Business.Services;

    [ApiController]
    [Route("[controller]")]
    public class InvoiceController
        : ControllerBase {

        public InvoiceController(IInvoiceService invoiceService) {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        [Route("summary")]
        public async Task<ActionResult<IInvoiceSummary>> Summary() {
            return Ok(await _invoiceService.GetSummaryAsync());
        }

        [HttpGet]
        [Route("seed")]
        public ActionResult Seed() {
            _invoiceService.Seed();
            return Ok();
        }

        private readonly IInvoiceService _invoiceService;
    }
}
