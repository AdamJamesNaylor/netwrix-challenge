
namespace Netwrix.Challenge.Data.Sql.Models {
    using Data.Models;

    class CustomerInvoiceSummary
        : ICustomerInvoiceSummary {

        public int Id { get; set; }
        public string Name { get; set; }
        public string MostRecentInvoiceReference { get; set; }
        public decimal MostRecentInvoiceAmount { get; set; }
        public int OutstandingInvoiceCount { get; set; }
        public decimal OutstandingInvoiceSum { get; set; }
        public decimal PaidInvoiceSum { get; set; }
    }
}