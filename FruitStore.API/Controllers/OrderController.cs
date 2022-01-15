using FruitStore.Business.Interfaces;
using FruitStore.Core.Models;
using FruitStore.DAL.Models;
using FruitStore.DTOS.OrderDTOs;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusiness _order;
        public OrderController(IOrderBusiness order)
        {
            _order = order;
           
        }
        [HttpGet]
        public async Task<IActionResult> GetAllByCustomerID(int cusID) {
            var result = new Result<OrderGettingDto>();
            try
            {
                var orders = await _order.GetByCustomerId(cusID);
                result.CreateSuccessResultList(orders);
                return Ok(result);
            }
            catch (Exception e) {
                result.CreateFailureResult("Error");
                return BadRequest(result);
            }
        }
        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID(int cartID)
        {
            var result = new Result<CreateOrderDto>();
            try
            {
                var order = await _order.GetOrderById(cartID);
                result.CreateSuccessResult(order);
                return Ok(result);
            }
            catch (Exception e)
            {
                result.CreateFailureResult("Error");
                return BadRequest(result);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto createRequest)
        {
            var result = new Result<bool>();
            var messages = new List<string>();
            try
            {
                var order = await _order.CreateOrder(createRequest);
                messages.Add("Create Order Success");
                result.CreateSuccessResult(order);
                return Ok(result);
            }
            catch (Exception e)
            {
                result.CreateFailureResult("Error");
                return BadRequest(result);
            }
        }
    }
}
