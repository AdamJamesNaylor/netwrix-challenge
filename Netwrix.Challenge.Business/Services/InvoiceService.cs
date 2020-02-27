
namespace Netwrix.Challenge.Business.Services {
    using System.Threading.Tasks;
    using Data.Repositories;
    using Models;

    public interface IInvoiceService {
        Task<IInvoiceSummary> GetSummaryAsync();
        void Seed();
    }

    public class InvoiceService
        : IInvoiceService {

        public InvoiceService(IInvoiceRepository invoiceRepository) {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<IInvoiceSummary> GetSummaryAsync() {
            return new InvoiceSummary {
                PaidInvoicesCount = await _invoiceRepository.RetrievePaidInvoicesCountAsync(),
                PaidInvoicesSum = await _invoiceRepository.RetrievePaidInvoicesSumAsync(),
                Customers = await _invoiceRepository.ListCustomerInvoiceSummaryAsync()
            };
        }

        public void Seed() {
            _invoiceRepository.Seed();
        }

        private readonly IInvoiceRepository _invoiceRepository;
    }
}