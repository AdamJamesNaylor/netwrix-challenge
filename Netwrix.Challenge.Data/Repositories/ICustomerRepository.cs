namespace Netwrix.Challenge.Data.Repositories {
    using System.Threading.Tasks;
    using Models;

    public interface ICustomerRepository {
        Task<ICustomer> RetrieveAsync(int customerId);
    }
}