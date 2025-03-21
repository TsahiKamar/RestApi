//########## Commnads for running the service ##########
//1. dotnet run  -> listen to http://localhost:5159
//2. ngrok http 5159(1. port number) -> listen to http://0.0.0.0:5159 
//   then see the command line Farwading Service URL - >
//   for example : Forwarding  https://3bc2-2a00-a040-192-6a3b-9587-7f1e-a1d3-8c82.ngrok-free.app 

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;  // Required for Swagger integration
using RestApi.BL;
using RestApi.Models;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Register Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();  // Adds OpenAPI (Swagger) support
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });

});

builder.Services.AddControllers();

builder.Services.AddTransient<CalcBL>();

// JWT Authentication setup
var jwtSecret = builder.Configuration.GetValue<string>("AppSettings:Secret");
var issuer = builder.Configuration.GetValue<string>("AppSettings:Issuer");
var audience = builder.Configuration.GetValue<string>("AppSettings:Audience");
    
// Configure JWT Bearer Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,//Use for JWT expiration
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
        };

     });


var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    
    // Enable Swagger for development environment
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        options.RoutePrefix = string.Empty; // To serve Swagger UI at the root
    });
}

app.UseRouting();

// Enable authentication and authorization
app.UseAuthentication();//JWT
app.UseAuthorization();

app.MapControllers();

//USE FOR NGROK - FOR ONLINE SERVICE
// Bind to all interfaces and port 5159
app.Urls.Add("http://0.0.0.0:5159");  // Make the app listen on 0.0.0.0:5159

app.Run();
