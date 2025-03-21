using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;

using RestApi.Models;
using RestApi.BL;


//NGROK 
//Account : 
//  user: tsahikamar@gmail.com
//  Pass:tsahikamar

//Token INSTALLATION
//Install your authtoken: https://dashboard.ngrok.com/get-started/your-authtoken
//Add Authtoken :
//ngrok config add-authtoken 2uY4NCeEnzqpGsSLXXhQSp8y3wI_5fPzUAqqzg1TRxB4pSmc3
//Authtoken saved to configuration file: /Users/tsahikamar/Library/Application Support/ngrok/ngrok.yml

//RestApi Service run command
//dotnet run

//NGROK Service run command - > Use for RestApi is Internet ONLINE
//ngrok http 5159 

//Current NGROK Internet url  
//https://e45c-2a00-a040-192-6a3b-4ca5-b099-873-7be5.ngrok-free.app

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Ensure all endpoints require JWT authentication
    public class CalculatorController : ControllerBase
    {
        private readonly CalcBL _calcBL;
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(CalcBL calcBL, ILogger<CalculatorController> logger)
        {
            _calcBL = calcBL;
            _logger = logger;
        }


       #region Public Methods
        //https://e45c-2a00-a040-192-6a3b-4ca5-b099-873-7be5.ngrok-free.app/api/calculator/multiply
        /// <summary>
        /// Multiply two numbers and return operation result
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("multiply")]
        public IActionResult Multiply([FromBody] CalculatorRequest request)
        {
            try
            {
                var result = _calcBL.Multiply(request.Num1, request.Num2);
                return Ok(new { result });
            }
            catch (Exception ex)                              
            {
                _logger.LogError(ex, "Error occurred during multiplication of {Num1} and {Num2}", request.Num1, request.Num2);
                return BadRequest(new { message = ex.Message });
            }
        }

        //https://e45c-2a00-a040-192-6a3b-4ca5-b099-873-7be5.ngrok-free.app/api/calculator/divide
        /// <summary>
        /// Divide two numbers and return operation result
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("divide")]
        public IActionResult Divide([FromBody] CalculatorRequest request)
        {
            try
            {
                var result = _calcBL.Divide(request.Num1, request.Num2);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during division of {Num1} and {Num2}", request.Num1, request.Num2);
                return BadRequest(new { message = ex.Message });
            }
        }

        //https://e45c-2a00-a040-192-6a3b-4ca5-b099-873-7be5.ngrok-free.app/api/calculator/add
        /// <summary>
        /// Add two numbers and return operation result
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult Add([FromBody] CalculatorRequest request)
        {
            try
            {
                var result = _calcBL.Add(request.Num1, request.Num2);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during addition of {Num1} and {Num2}", request.Num1, request.Num2);
                return BadRequest(new { message = ex.Message });
            }
        }

        //https://e45c-2a00-a040-192-6a3b-4ca5-b099-873-7be5.ngrok-free.app/api/calculator/subtract
        /// <summary>
        /// Substruct two numbers and return operation result
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("subtract")]
        public IActionResult Subtract([FromBody] CalculatorRequest request)
        {
            try
            {
                var result = _calcBL.Subtract(request.Num1, request.Num2);
                return Ok(new { result });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during subtraction of {Num1} and {Num2}", request.Num1, request.Num2);
                return BadRequest(new { message = ex.Message });
            }
        }
    
        #endregion
    }

   
}
