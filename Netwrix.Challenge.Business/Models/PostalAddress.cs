
namespace Netwrix.Challenge.Business.Models {
    public interface IPostalAddress {
        string Line1 { get; }
        string Line2 { get; }
        Postcode Postcode { get; }
    }

    public class PostalAddress {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public Postcode Postcode { get; set; }
    }
}