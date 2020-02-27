
namespace Netwrix.Challenge.API.Tests
{
    using System.Threading.Tasks;
    using Business.Services;
    using Controllers;
    using Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;

    public class CustomerControllerTests {

        [Fact]
        public async Task Get_WithId_CallsService() {
            //Arrange
            var mockService = new Mock<ICustomerService>();
            var sut = new CustomerController(mockService.Object);

            //Act
            var result = await sut.Get(1);

            //Assert
            mockService.Verify(s => s.GetAsync(It.Is<int>(i => i == 1)), Times.Once());
        }

        [Fact]
        public async Task Get_WithNonExistantCustomerId_ReturnsNotFound() {
            //Arrange
            var mockService = new Mock<ICustomerService>();
            mockService.Setup(s => s.GetAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            var sut = new CustomerController(mockService.Object);

            //Act
            var result = await sut.Get(1);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

    }
}
