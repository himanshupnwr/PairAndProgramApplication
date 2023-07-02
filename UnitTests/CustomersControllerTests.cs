using AspNetBasicApplication;
using AspNetBasicApplication.Controllers;
using AspNetBasicApplication.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.EntityFrameworkCore;

[TestFixture]
public class CustomersControllerTests
{
    private CustomersController _controller;
    private Mock<DataContext> _mockContext;
    private Mock<IConfiguration> _mockConfiguration;

    //[SetUp]
    //public void Setup()
    //{
    //    Initialize the mock DataContext
    //    _mockContext = new Mock<DataContext>();
    //    _controller = new CustomersController(_mockContext.Object, _mockConfiguration.Object);
    //}

    [Test]
    public async Task GetEmployees_WhenCalled_ReturnsEmployeeListAsync()
    {
        // Arrange
        var customerContextMock = new Mock<DataContext>();
        customerContextMock.Setup<DbSet<Customer>>(x => x.Customers)
            .ReturnsDbSet(UnitTests.TestDataHelper.GetFakeEmployeeList());
        //Act
        CustomersController customersController = new(customerContextMock.Object, _mockConfiguration.Object);
        var customers = (await customersController.GetCustomers()).Value;
        //Assert
        Assert.NotNull(customers);
        Assert.That(customers.Count(), Is.EqualTo(2));
    }
}
