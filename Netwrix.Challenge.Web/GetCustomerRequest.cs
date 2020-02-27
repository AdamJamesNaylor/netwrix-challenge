namespace Netwrix.Challenge.Web {
    using System;
    using RestSharp;

    public class GetCustomerRequest
        : RestRequest {
        public GetCustomerRequest(int customerId)
            : base(new Uri("customer", UriKind.Relative), Method.GET) {
            AddQueryParameter("customerId", customerId.ToString());
        }
    }
}