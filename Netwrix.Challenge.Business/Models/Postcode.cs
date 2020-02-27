namespace Netwrix.Challenge.Business.Models {
    using System.Diagnostics;

    [DebuggerDisplay("{NormalisedValue}")]
    public class Postcode { 

        public static implicit operator Postcode(string postcode) {
            return new Postcode(postcode);
        }

        public Postcode(string postcode) {
            Value = postcode;
        }

        public string NormalisedValue => Normalise(Value);

        public static string Normalise(string postcode) {
            if (string.IsNullOrEmpty(postcode))
                return postcode;

            return postcode.Trim()
                .Replace(" ", "")
                .ToUpper();
        }

        public string Value { get; }
    }
}