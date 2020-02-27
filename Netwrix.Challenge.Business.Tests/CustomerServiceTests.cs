namespace Netwrix.Challenge.Business.Tests {
    using System.Threading.Tasks;
    using Data.Repositories;
    using Moq;
    using Services;
    using Xunit;

    public class CustomerServiceTests {

        [Fact]
        public async Task Get_Always_CallsRetrieveOnRepo() {

            //Arrange
            var mockRepo = new Mock<ICustomerRepository>();
            mockRepo.Setup(r => r.RetrieveAsync(It.Is<int>(i => i == 1)))
                .ReturnsAsync(() => new Data.Sql.Models.Customer());
            var sut = new CustomerService(mockRepo.Object);

            //Act
            var result = await sut.GetAsync(1);

            //Assert
            mockRepo.Verify(repo => repo.RetrieveAsync(It.Is<int>(i => i == 1)), Times.Once);
        }
    }
}