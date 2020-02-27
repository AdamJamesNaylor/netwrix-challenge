namespace Netwrix.Challenge.Data.Models {
    public interface ICustomerInvoiceSummary {
        int Id { get; }
        string Name { get; }
        string MostRecentInvoiceReference { get; }
        decimal MostRecentInvoiceAmount { get; }
        int OutstandingInvoiceCount { get; }
        decimal OutstandingInvoiceSum { get; }
        decimal PaidInvoiceSum { get; }
    }
}