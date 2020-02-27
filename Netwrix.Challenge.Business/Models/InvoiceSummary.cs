
namespace Netwrix.Challenge.Business.Models {
    using System.Collections.Generic;
    using Data.Models;

    public interface IInvoiceSummary {
        long PaidInvoicesCount { get; }
        decimal PaidInvoicesSum { get; }

        IEnumerable<ICustomerInvoiceSummary> Customers { get; }
    }

    public class InvoiceSummary
        : IInvoiceSummary {
        public long PaidInvoicesCount { get; set; }
        public decimal PaidInvoicesSum { get; set; }

        public IEnumerable<ICustomerInvoiceSummary> Customers { get; set; }
    }
}