
namespace Netwrix.Challenge.Web.Controllers {
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using RestSharp;

    public class HomeController
        : Controller {

        public HomeController(IRestClient restClient) {
            _restClient = restClient;
        }

        public async Task<IActionResult> Index() {
            var request = new InvoiceSummaryRequest();
            var response = await _restClient.ExecuteGetAsync<InvoiceSummaryViewModel>(request);
            return View(response.Data);
        }

        [HttpGet("home/address/{customerId}")]
        public async Task<IActionResult> Address(int customerId)
        {
            var request = new GetCustomerRequest(customerId);
            var response = await _restClient.ExecuteGetAsync<CustomerViewModel>(request);
            return View(response.Data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        private readonly IRestClient _restClient;
    }
}