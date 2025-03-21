using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApi.Controllers;
using RestApi.BL;
using RestApi.Models;
using System;
//ddd
namespace RestApi.Tests
{
    public class CalculatorControllerTests
    {
        private readonly Mock<CalcBL> _mockCalcBL;
        private readonly Mock<ILogger<CalculatorController>> _mockLogger;
        private readonly CalculatorController _controller;
        

        public CalculatorControllerTests()
        {
            // Mock the dependencies
            _mockCalcBL = new Mock<CalcBL>();
            _mockLogger = new Mock<ILogger<CalculatorController>>();

            // Initialize the controller with mocked dependencies
            _controller = new CalculatorController(_mockCalcBL.Object, _mockLogger.Object);
        }

        #region Multiply Test

        [Fact]
        public void Multiply_ReturnsOkResult_WhenSuccessful()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 2, Num2 = 3 };
            _mockCalcBL.Setup(x => x.Multiply(request.Num1, request.Num2)).Returns(6);

            // Act
            var result = _controller.Multiply(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            dynamic returnValue = okResult.Value;
            Assert.Equal(6, returnValue.result);
        }

        [Fact]
        public void Multiply_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 2, Num2 = 0 }; // To simulate divide by zero
            _mockCalcBL.Setup(x => x.Multiply(request.Num1, request.Num2)).Throws(new Exception("Multiplication failed"));

            // Act
            var result = _controller.Multiply(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            dynamic returnValue = badRequestResult.Value;
            Assert.Equal("Multiplication failed", returnValue.message);
        }

        #endregion

        #region Add Test

        [Fact]
        public void Add_ReturnsOkResult_WhenSuccessful()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 2, Num2 = 3 };
            _mockCalcBL.Setup(x => x.Add(request.Num1, request.Num2)).Returns(5);

            // Act
            var result = _controller.Add(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            dynamic returnValue = okResult.Value;
            Assert.Equal(5, returnValue.result);
        }

        [Fact]
        public void Add_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 2, Num2 = 0 };
            _mockCalcBL.Setup(x => x.Add(request.Num1, request.Num2)).Throws(new Exception("Addition failed"));

            // Act
            var result = _controller.Add(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            dynamic returnValue = badRequestResult.Value;
            Assert.Equal("Addition failed", returnValue.message);
        }

        #endregion

        #region Subtract Test

        [Fact]
        public void Subtract_ReturnsOkResult_WhenSuccessful()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 5, Num2 = 3 };
            _mockCalcBL.Setup(x => x.Subtract(request.Num1, request.Num2)).Returns(2);

            // Act
            var result = _controller.Subtract(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            dynamic returnValue = okResult.Value;
            Assert.Equal(2, returnValue.result);
        }

        [Fact]
        public void Subtract_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 5, Num2 = 0 };
            _mockCalcBL.Setup(x => x.Subtract(request.Num1, request.Num2)).Throws(new Exception("Subtraction failed"));

            // Act
            var result = _controller.Subtract(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            dynamic returnValue = badRequestResult.Value;
            Assert.Equal("Subtraction failed", returnValue.message);
        }

        #endregion

        #region Divide Test

        [Fact]
        public void Divide_ReturnsOkResult_WhenSuccessful()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 6, Num2 = 3 };
            _mockCalcBL.Setup(x => x.Divide(request.Num1, request.Num2)).Returns(2);

            // Act
            var result = _controller.Divide(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            dynamic returnValue = okResult.Value;
            Assert.Equal(2, returnValue.result);
        }

        [Fact]
        public void Divide_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var request = new CalculatorRequest { Num1 = 6, Num2 = 0 }; // Divide by zero
            _mockCalcBL.Setup(x => x.Divide(request.Num1, request.Num2)).Throws(new Exception("Division by zero"));

            // Act
            var result = _controller.Divide(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            dynamic returnValue = badRequestResult.Value;
            Assert.Equal("Division by zero", returnValue.message);
        }

        #endregion
    }
}
