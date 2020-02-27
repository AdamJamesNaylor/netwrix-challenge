
namespace Netwrix.Challenge.Business.Services {
    using System.Threading.Tasks;
    using Data.Models;
    using Data.Repositories;
    using Models;

    public interface ICustomerService {
        Task<Models.ICustomer> GetAsync(int customerId);
    }

    public class CustomerService
        : ICustomerService {

        public CustomerService(ICustomerRepository customerRepository) {
            _customerRepository = customerRepository;
        }

        public async Task<Models.ICustomer> GetAsync(int customerId) {
            var customer = await _customerRepository.RetrieveAsync(customerId);
            return Map(customer);
        }

        private Models.ICustomer Map(Data.Models.ICustomer customer) {
            if (customer == null)
                return null;
            return new Customer {
                Id = customer.CustomerId,
                Name = customer.Name,
                Address = new PostalAddress {
                    Line1 = customer.Address1,
                    Line2 = customer.Address2,
                    Postcode = new Postcode(customer.Postcode)
                },
                TelephoneNumber = new TelephoneNumber(customer.Telephone)
            };
        }

        private readonly ICustomerRepository _customerRepository;
    }
}