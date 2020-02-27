
namespace Netwrix.Challenge.Data.Sql.Repositories {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Models;
    using Data.Repositories;
    using Models;

    using Microsoft.EntityFrameworkCore;

    public class InvoiceRepository
        : IInvoiceRepository {

        public InvoiceRepository(INetwrixDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<IInvoice>> ListAsync(bool isPaid) {
            return await ListInternal(isPaid)
                .ToListAsync();
        }

        public async Task<long> RetrievePaidInvoicesCountAsync() {
            return await ListInternal(true)
                .LongCountAsync();
        }

        public async Task<decimal> RetrievePaidInvoicesSumAsync() {
            return await ListInternal(true)
                .SumAsync(i => i.Value);
        }

        public async Task<IEnumerable<ICustomerInvoiceSummary>> ListCustomerInvoiceSummaryAsync() {

            //Downgraded EF due to https://stackoverflow.com/questions/58138556/client-side-groupby-is-not-supported

            return await _dbContext.Invoices
                .GroupBy(invoice => new { invoice.CustomerId })
                .Join(_dbContext.Customers, grp => grp.Key.CustomerId, customer => customer.CustomerId,
                    (grp, customer) => new { grp, customer })
                .OrderBy(t => t.customer.Name)
                .Select(t => new CustomerInvoiceSummary
                {
                    Id = t.grp.Key.CustomerId,
                    Name = t.customer.Name,
                    PaidInvoiceSum = t.grp.Where(i => i.IsPaid).Sum(i => i.Value),
                    OutstandingInvoiceSum = t.grp.Where(i => !i.IsPaid).Sum(i => i.Value),
                    MostRecentInvoiceAmount = t.grp.OrderByDescending(i => i.InvoiceDate).First().Value,
                    MostRecentInvoiceReference = t.grp.OrderByDescending(i => i.InvoiceDate).First().Ref,
                    OutstandingInvoiceCount = t.grp.Count(i => !i.IsPaid)
                }).ToListAsync();
        }

        public void Seed() {
            _dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [Invoices]");
            _dbContext.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");

            for (var c = 1; c <= 100; ++c) {
                var customer = new Customer {
                    Name = "Customer-" + c,
                    Address1 = "Address1-" + c,
                    Address2 = "Address2-" + c,
                    Postcode = "Postcode-" + c,
                    Telephone = "02380" + c
                };

                _dbContext.Customers.Add(customer);
            }

            _dbContext.SaveChanges();

            var rnd = new Random();
            
            foreach (var customer in _dbContext.Customers) {
                for (var i = 1; i <= 1000; ++i) {
                    var invoice = new Invoice {
                        CustomerId = customer.CustomerId,
                        IsPaid = Convert.ToBoolean(rnd.Next(0, 2)),
                        Ref = "Ref-" + i,
                        InvoiceDate = DateTime.Now,
                        Value = rnd.Next(0, 100000) / 100.00m
                    };

                    _dbContext.Invoices.Add(invoice);
                }
            }

            _dbContext.SaveChanges();
        }

        private IQueryable<IInvoice> ListInternal(bool isPaid) {
            return _dbContext.Invoices
                .Where(i => i.IsPaid == isPaid);
        }

        private readonly INetwrixDbContext _dbContext;

    }
}