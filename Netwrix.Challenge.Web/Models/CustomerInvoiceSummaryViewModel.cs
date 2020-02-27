namespace Netwrix.Challenge.Web.Models {
    public class CustomerInvoiceSummaryViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MostRecentInvoiceReference { get; set; }
        public decimal MostRecentInvoiceAmount { get; set; }
        public int OutstandingInvoiceCount { get; set; }
        public decimal OutstandingInvoiceSum { get; set; }
        public decimal PaidInvoiceSum { get; set; }
    }
}