// using Microsoft.AspNetCore.Mvc.Testing;
// using System.Net.Http;
// using System.Threading.Tasks;
// using Xunit;

// //dotnet restore

// //########## run dotnet test command ########## 

// namespace UT.Tests
// {
//     public class AuthControllerIntegrationTests : IClassFixture<WebApplicationFactory<RestApi.Startup>>
//     {
//         private readonly HttpClient _client;

//         public AuthControllerIntegrationTests(WebApplicationFactory<RestApi.Startup> factory)
//         {
//             _client = factory.CreateClient();
//         }

//         [Fact]
//         public async Task Login_ReturnsToken_WhenValidCredentialsAreProvided()
//         {
//             // Arrange
//             var loginRequest = new
//             {
//                 Username = "test",
//                 Password = "password"
//             };

//             var response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);

//             // Assert
//             response.EnsureSuccessStatusCode();
//             var result = await response.Content.ReadAsAsync<dynamic>();
//             Assert.NotNull(result.Token);
//         }

//         [Fact]
//         public async Task Login_ReturnsUnauthorized_WhenInvalidCredentialsAreProvided()
//         {
//             // Arrange
//             var loginRequest = new
//             {
//                 Username = "test",
//                 Password = "wrongPassword"
//             };

//             var response = await _client.PostAsJsonAsync("/api/auth/login", loginRequest);

//             // Assert
//             Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
//         }
//     }
// }
