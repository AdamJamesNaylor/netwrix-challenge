namespace Netwrix.Challenge.Business.Models {
    using System.Diagnostics;

    [DebuggerDisplay("{NormalisedValue}")]
    public class TelephoneNumber {

        public static implicit operator TelephoneNumber(string telephoneNumber) {
            return new TelephoneNumber(telephoneNumber);
        }

        public TelephoneNumber(string telephoneNumber) {
            Value = telephoneNumber;
        }

        public string NormalisedValue => Normalise(Value);

        public static string Normalise(string telephoneNumber) {
            if (string.IsNullOrEmpty(telephoneNumber))
                return telephoneNumber;

            return telephoneNumber.Trim()
                .Replace(" ", "")
                .ToUpper();
        }

        public string Value { get; }
    }
}