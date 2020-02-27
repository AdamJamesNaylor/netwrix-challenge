
namespace Netwrix.Challenge.Business.Models {
    using System.Diagnostics;

    public interface ICustomer
        : IIdentifiable {

        int Id { get; }
        string Name { get; }
        PostalAddress Address { get; }
        TelephoneNumber TelephoneNumber { get; }
    }

    [DebuggerDisplay("{Id}: {Name}")]
    public class Customer
        : ICustomer {

        public int Id { get; set; }
        public string Name { get; set; }
        public PostalAddress Address { get; set; }
        public TelephoneNumber TelephoneNumber { get; set; }
    }
}