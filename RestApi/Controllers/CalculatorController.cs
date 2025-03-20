using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

using RestApi.Models;
using RestApi.BL;


//authentication failed: Usage of ngrok requires a verified account and authtoken.
//ERROR:  
//ERROR:  Sign up for an account: https://dashboard.ngrok.com/signup
//ERROR:  Install your authtoken: https://dashboard.ngrok.com/get-started/your-authtoken

//https://ngrok.com/downloads/mac-os

//ngrok for online service - > internet 
//run : ngrok http 5159 

//Add Authtoken 
//ngrok config add-authtoken 2uY4NCeEnzqpGsSLXXhQSp8y3wI_5fPzUAqqzg1TRxB4pSmc3
//Authtoken saved to configuration file: /Users/tsahikamar/Library/Application Support/ngrok/ngrok.yml

//Command
//ngrok http http://localhost:5159

//Web Interface                 http://127.0.0.1:4040                                                                                      

//https://e45c-2a00-a040-192-6a3b-4ca5-b099-873-7be5.ngrok-free.app

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Ensure all endpoints require JWT authentication
    public class CalculatorController : ControllerBase
    {
        private readonly CalcBL _calcBL;

   
        public CalculatorController(CalcBL calcBL)
        {
            _calcBL = calcBL;
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
                return BadRequest(new { message = ex.Message });
            }
        }
    
        #endregion
    }

   
}
