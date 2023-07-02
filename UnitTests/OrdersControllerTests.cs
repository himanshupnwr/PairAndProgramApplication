using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetBasicApplication.Controllers;
using AspNetBasicApplication.Model;
using AspNetBasicApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;

[TestFixture]
public class OrdersControllerTests
{
    private OrdersController _controller;
    private Mock<DataContext> _mockContext;
    private Mock<IConfiguration> _mockConfiguration;

    [SetUp]
    public void Setup()
    {
        // Initialize the mock DataContext and IConfiguration
        _mockContext = new Mock<DataContext>();
        _mockConfiguration = new Mock<IConfiguration>();
        _controller = new OrdersController(_mockContext.Object, _mockConfiguration.Object);
    }
}
