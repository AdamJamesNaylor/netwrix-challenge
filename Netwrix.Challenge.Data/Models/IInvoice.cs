namespace Netwrix.Challenge.Data.Models {
    using System;

    public interface IInvoice {
        int InvoiceId { get; set; }
        int CustomerId { get; set; }
        string Ref { get; set; }
        DateTime? InvoiceDate { get; set; }
        bool IsPaid { get; set; }
        decimal Value { get; set; }
    }
}