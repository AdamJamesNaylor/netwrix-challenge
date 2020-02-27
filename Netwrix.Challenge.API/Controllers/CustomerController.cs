
namespace Netwrix.Challenge.API.Controllers {

    using System.Threading.Tasks;
    using Business.Models;
    using Microsoft.AspNetCore.Mvc;
    using Business.Services;

    [ApiController]
    [Route("[controller]")]
    public class CustomerController
        : ControllerBase {

        public CustomerController(ICustomerService customerService) {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<ICustomer>> Get(int customerId) {
            var customer = await _customerService.GetAsync(customerId);
            if (customer == null)
                return NotFound();

            return Ok(new {
                Id = customer.Id,
                Name = customer.Name,
                Address1 = customer.Address.Line1,
                Address2 = customer.Address.Line2,
                Postcode = customer.Address.Postcode.NormalisedValue,
                TelephoneNumber = customer.TelephoneNumber.NormalisedValue
            });
        }

        private readonly ICustomerService _customerService;
    }
}
