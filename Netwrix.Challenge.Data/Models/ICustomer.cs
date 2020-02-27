namespace Netwrix.Challenge.Data.Models {

    public interface ICustomer {
        int CustomerId { get; }
        string Name { get; }
        string Address1 { get; }
        string Address2 { get; }
        string Postcode { get; }
        string Telephone { get; }
    }
}