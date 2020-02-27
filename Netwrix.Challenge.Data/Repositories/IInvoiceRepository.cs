namespace Netwrix.Challenge.Data.Repositories {
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IInvoiceRepository {

        Task<IEnumerable<IInvoice>> ListAsync(bool isPaid);
        Task<long> RetrievePaidInvoicesCountAsync();
        Task<decimal> RetrievePaidInvoicesSumAsync();
        Task<IEnumerable<ICustomerInvoiceSummary>> ListCustomerInvoiceSummaryAsync();
        void Seed();
    }
}