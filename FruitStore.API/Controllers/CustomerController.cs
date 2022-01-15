using FruitStore.Business.Interfaces;
using FruitStore.Core.Models;
using FruitStore.DTOS.CustomerDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBusiness _customer;
        public CustomerController(ICustomerBusiness customer)
        {
            _customer = customer;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest loginRequest) {
            var result = new Result<object>();
            var customer = await _customer.Authenticate(loginRequest);
            if (customer != null)
            {
                result.CreateSuccessResult(customer);
            }
            else {
                var error = "Phone number/Password not correct";
                result.CreateFailureResult(error);
            }
            return Ok(result);          
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest) {
            var result = new Result<string>();
            var registerStatus = await _customer.Register(registerRequest);
            if (registerStatus)
            {
                result.CreateSuccessResult("Create Successful");
                return Ok(result);
            }
            else {
                result.CreateFailureResult("Create Failed");
                return BadRequest(result);
            }
        }
       
    }
}
