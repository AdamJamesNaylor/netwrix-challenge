
namespace Netwrix.Challenge.Business.Tests {
    using System.Threading.Tasks;
    using Data.Repositories;
    using Moq;
    using Services;
    using Xunit;

    public class InvoiceServiceTests {

        [Fact]
        public async Task GetInvoiceSummary_Always_CallsAllThreeSummaryMethods() {
            //Arrange
            var mockRepo = new Mock<IInvoiceRepository>();
            var sut = new InvoiceService(mockRepo.Object);

            //Act
            var result = await sut.GetSummaryAsync();

            //Assert
            mockRepo.Verify(repo => repo.RetrievePaidInvoicesCountAsync(), Times.Once);
            mockRepo.Verify(repo => repo.RetrievePaidInvoicesSumAsync(), Times.Once);
            mockRepo.Verify(repo => repo.ListCustomerInvoiceSummaryAsync(), Times.Once);
        }
    }
}