// using Moq;
// using RestApi.Controllers;
// using Xunit;
// using Microsoft.AspNetCore.Mvc;

// namespace UT.Tests
// {
//     public class AuthControllerTests
//     {
//         private readonly TestTokenController _controller;

//         private readonly Mock<JwtTokenService> _jwtTokenServiceMock;

//         public AuthControllerTests()
//         {
//             // Mock the JwtTokenService
//             _jwtTokenServiceMock = new Mock<JwtTokenService>();

//             // Set up mock to return a fake token
//             _jwtTokenServiceMock.Setup(service => service.GenerateToken(It.IsAny<string>()))
//                 .Returns("FakeJWTToken");

//             // Create the controller with the mocked service
//             _controller = new AuthController(_jwtTokenServiceMock.Object);
//         }

//         [Fact]
//         public void Login_ReturnsToken_WhenValidCredentialsAreProvided()
//         {
//             // Arrange
//             var loginRequest = new LoginRequest
//             {
//                 Username = "test",
//                 Password = "password"
//             };

//             // Act
//             var result = _controller.Login(loginRequest);

//             // Assert
//             var okResult = Assert.IsType<OkObjectResult>(result);
//             var response = okResult.Value as dynamic;
//             Assert.Equal("FakeJWTToken", response.Token);
//         }

//         [Fact]
//         public void Login_ReturnsUnauthorized_WhenInvalidCredentialsAreProvided()
//         {
//             // Arrange
//             var loginRequest = new LoginRequest
//             {
//                 Username = "test",
//                 Password = "wrongPassword"
//             };

//             // Act
//             var result = _controller.Login(loginRequest);

//             // Assert
//             Assert.IsType<UnauthorizedResult>(result);
//         }
//     }
// }
