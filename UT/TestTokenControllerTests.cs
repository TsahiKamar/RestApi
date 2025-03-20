using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RestApi.Controllers;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

//command : dotnet test

namespace RestApi.Tests
{
    public class TestTokenControllerTests
    {
        private readonly TestTokenController _controller;
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<IOptions<AppSettings>> _mockAppSettings;

        public TestTokenControllerTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockAppSettings = new Mock<IOptions<AppSettings>>();

            // Set up the AppSettings mock with example values
            var appSettings = new AppSettings
            {
                Secret = "MHSDFAWSDHFIU8766532JXXXXXXXXXXXXXXXDEV",
                Issuer = "issuer",
                Audience = "audience",
                ExpirationMinutes = 30
            };
          
            _mockAppSettings.Setup(x => x.Value).Returns(appSettings);

            _controller = new TestTokenController(_mockConfiguration.Object, _mockAppSettings.Object);
        }

        [Fact]
        public void GenerateTestToken_ReturnsOkResult_WithValidCredentials()
        {
            // Arrange
            var loginRequest = new LoginRequest
            {
                Username = "test",
                Password = "password"
            };

            // Act
            var result = _controller.GenerateTestToken(loginRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<dynamic>(okResult.Value);
            Assert.NotNull(returnValue.token);

            // Validate that the token is a valid JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(returnValue.token.ToString());
            Assert.Equal("issuer", token.Issuer);
            Assert.Equal("audience", token.Audiences.First());
            Assert.Equal("test", token.Subject);
        }

        [Fact]
        public void GenerateTestToken_ReturnsUnauthorized_WithInvalidCredentials()
        {
            // Arrange
            var loginRequest = new LoginRequest
            {
                Username = "invalidUser",
                Password = "wrongPassword"
            };

            // Act
            var result = _controller.GenerateTestToken(loginRequest);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
