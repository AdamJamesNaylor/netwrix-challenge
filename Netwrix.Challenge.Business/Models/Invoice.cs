
namespace Netwrix.Challenge.Business.Models {
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("{Id}: {Reference}")]
    public class Invoice
        : IIdentifiable {

        public int Id { get; }
        public string Reference { get; }
        public DateTime InvoiceDate { get; }
        public bool IsPaid { get; } = false;
        public decimal Value { get; }
    }
}