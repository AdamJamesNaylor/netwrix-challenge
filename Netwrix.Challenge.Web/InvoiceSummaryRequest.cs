namespace Netwrix.Challenge.Web {
    using System;
    using RestSharp;

    public class InvoiceSummaryRequest
        : RestRequest {
        public InvoiceSummaryRequest()
            : base(new Uri("invoice/summary", UriKind.Relative), Method.GET) {
            
        }
    }
}