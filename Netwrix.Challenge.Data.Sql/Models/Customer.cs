
namespace Netwrix.Challenge.Data.Sql.Models {
    using Data.Models;

    public class Customer
        : ICustomer {

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Postcode { get; set; }
        public string Telephone { get; set; }
    }
}