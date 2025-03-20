using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using RestApi.Controllers;
using RestApi.Models;
using RestApi.BL;
using System;
///hghg
namespace RestApi.Tests
{
    public class CalculatorControllerTests
    {
        private readonly Mock<CalcBL> _mockCalcBL;
        private readonly CalculatorController _controller;

        public CalculatorControllerTests()
        {
            _mockCalcBL = new Mock<CalcBL>();
            _controller = new CalculatorController(_mockCalcBL.Object);
        }

        [Fact]
        public void Multiply_ReturnsOkResult_WithValidRequest()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 5, Num2 = 10 };
            var expectedResult = 50;

            _mockCalcBL.Setup(bl => bl.Multiply(request.Num1, request.Num2)).Returns(expectedResult);

            // Act
            var result = _controller.Multiply(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<dynamic>(okResult.Value);
            Assert.Equal(expectedResult, returnValue.result);
        }

        [Fact]
        public void Multiply_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 5, Num2 = 0 }; // For example, division by zero
            _mockCalcBL.Setup(bl => bl.Multiply(request.Num1, request.Num2))
                       .Throws(new Exception("An error occurred"));

            // Act
            var result = _controller.Multiply(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<dynamic>(badRequestResult.Value);
            Assert.Equal("An error occurred", returnValue.message);
        }

        [Fact]
        public void Divide_ReturnsOkResult_WithValidRequest()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 10, Num2 = 2 };
            var expectedResult = 5;

            _mockCalcBL.Setup(bl => bl.Divide(request.Num1, request.Num2)).Returns(expectedResult);

            // Act
            var result = _controller.Divide(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<dynamic>(okResult.Value);
            Assert.Equal(expectedResult, returnValue.result);
        }

        [Fact]
        public void Divide_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 10, Num2 = 0 }; // Divide by zero scenario
            _mockCalcBL.Setup(bl => bl.Divide(request.Num1, request.Num2))
                       .Throws(new Exception("Cannot divide by zero"));

            // Act
            var result = _controller.Divide(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<dynamic>(badRequestResult.Value);
            Assert.Equal("Cannot divide by zero", returnValue.message);
        }

        [Fact]
        public void Add_ReturnsOkResult_WithValidRequest()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 5, Num2 = 10 };
            var expectedResult = 15;

            _mockCalcBL.Setup(bl => bl.Add(request.Num1, request.Num2)).Returns(expectedResult);

            // Act
            var result = _controller.Add(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<dynamic>(okResult.Value);
            Assert.Equal(expectedResult, returnValue.result);
        }

        [Fact]
        public void Add_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 5, Num2 = 10 };
            _mockCalcBL.Setup(bl => bl.Add(request.Num1, request.Num2))
                       .Throws(new Exception("An error occurred"));

            // Act
            var result = _controller.Add(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<dynamic>(badRequestResult.Value);
            Assert.Equal("An error occurred", returnValue.message);
        }

        [Fact]
        public void Subtract_ReturnsOkResult_WithValidRequest()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 10, Num2 = 5 };
            var expectedResult = 5;

            _mockCalcBL.Setup(bl => bl.Subtract(request.Num1, request.Num2)).Returns(expectedResult);

            // Act
            var result = _controller.Subtract(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<dynamic>(okResult.Value);
            Assert.Equal(expectedResult, returnValue.result);
        }

        [Fact]
        public void Subtract_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 10, Num2 = 5 };
            _mockCalcBL.Setup(bl => bl.Subtract(request.Num1, request.Num2))
                       .Throws(new Exception("An error occurred"));

            // Act
            var result = _controller.Subtract(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var returnValue = Assert.IsType<dynamic>(badRequestResult.Value);
            Assert.Equal("An error occurred", returnValue.message);
        }
    }
}
