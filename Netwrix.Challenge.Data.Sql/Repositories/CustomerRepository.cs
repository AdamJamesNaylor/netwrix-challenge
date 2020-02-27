
namespace Netwrix.Challenge.Data.Sql.Repositories {
    using System.Threading.Tasks;
    using Data.Models;
    using Data.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class CustomerRepository
        : ICustomerRepository {

        public CustomerRepository(INetwrixDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<ICustomer> RetrieveAsync(int customerId) {
            return await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        private readonly INetwrixDbContext _dbContext;
    }
}