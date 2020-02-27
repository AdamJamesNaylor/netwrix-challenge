
namespace Netwrix.Challenge.Data.Sql.Models {
    using System;
    using Data.Models;

    public class Invoice
        : IInvoice { 

        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public string Ref { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public bool IsPaid { get; set; }
        public decimal Value { get; set; }
    }
}