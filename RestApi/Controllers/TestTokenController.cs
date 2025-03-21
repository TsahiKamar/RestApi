
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;
using RestApi.Models;

namespace RestApi.Controllers
{

  public class TestTokenController : ControllerBase
  {
    private readonly IConfiguration _configuration;

    private readonly AppSettings _appSettings;
    private readonly ILogger<TestTokenController> _logger;


    public TestTokenController(IConfiguration configuration,IOptions<AppSettings> appSettings,ILogger<TestTokenController> logger)
    {
        _configuration = configuration;
        _appSettings = appSettings.Value;
        _logger = logger;
    }

    //https://e45c-2a00-a040-192-6a3b-4ca5-b099-873-7be5.ngrok-free.app/api/multiply
    /// <summary>
    /// Create init JWT token after validate username & password
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    [HttpPost("api/token")]
    public IActionResult GenerateTestToken([FromBody] LoginRequest login)
    {
        try 
        {
        
            if (login.Username == _appSettings.Username && login.Password == _appSettings.Password) 
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, login.Username),
                    new Claim(JwtRegisteredClaimNames.Sub, login.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _appSettings.Issuer,
                    audience: _appSettings.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(_appSettings.ExpirationMinutes),//Token expires 
                    signingCredentials: creds
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }

            return Unauthorized();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred during generate token");
            return BadRequest(new { message = ex.Message });
        }
    }
  }

}