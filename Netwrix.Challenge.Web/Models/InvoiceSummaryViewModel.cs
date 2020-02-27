
namespace Netwrix.Challenge.Web.Models {
    using System.Collections.Generic;

    public class InvoiceSummaryViewModel {
        public long PaidInvoicesCount { get; set; }
        public decimal PaidInvoicesSum { get; set; }

        public IEnumerable<CustomerInvoiceSummaryViewModel> Customers { get; set; }
    }
}