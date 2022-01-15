using FruitStore.Business.Interfaces;
using FruitStore.Core.Models;
using FruitStore.DAL.Enums;
using FruitStore.DAL.Models;
using FruitStore.DTOS.ProductDTOs;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductBusiness _product;
        public ProductController(IProductBusiness product)
        {
            _product = product;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var result = new Result<Fruit>();
            try
            {   
                var products = await _product.GetAll();
                result.CreateSuccessResultList(products);
                return Ok(result);
            }
            catch (Exception e) {
                result.CreateFailureResult("Error");
                return BadRequest(result);
            }

        }
        [HttpGet("{ID}")]
        public async Task<IActionResult> getByID(int ID) {
            var result = new Result<Fruit>();
            try
            {
                var product = await _product.GetByID(ID);
                result.CreateSuccessResult(product);
                return Ok(result);
            }
            catch (Exception e)
            {
                result.CreateFailureResult("Error");
                return BadRequest(result);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CreateDTO createRequest) {
            var result = new Result<string>();
            var messages = new List<string>();
            var productMapped = new Fruit()
            {
                FruitName = createRequest.FruitName,
                Price = createRequest.Price,
                Descrip = createRequest.Descrip,
                ImpDate = DateTime.Now,
                Quantity = createRequest.Quantity,
                IsImported = createRequest.IsImported,
                Img = createRequest.Img,
                IdCate = createRequest.IdCate,
                IdOrigin = createRequest.IdOrigin,
                IdUnit = createRequest.IdUnit
            };
            var status = await _product.Insert(productMapped);
            if (status) {
                result.CreateSuccessResult(status.ToString());
                messages.Add("Create Success");
                result.Messages = messages;
                return Ok(result);
            }

            result.CreateFailureResult("Create Failed");
            return BadRequest(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDTO updateRequest) {
            var result = new Result<string>();
            var messages = new List<string>();
            var productMapped = new Fruit()
            {
                FruitName = updateRequest.FruitName,
                Price = updateRequest.Price,
                Descrip = updateRequest.Descrip,
                ImpDate = updateRequest.ImpDate,
                Quantity = updateRequest.Quantity,
                IsImported = updateRequest.IsImported,
                Img = updateRequest.Img,
                IdCate = updateRequest.IdCate,
                IdOrigin = updateRequest.IdOrigin,
                IdUnit = updateRequest.IdUnit
            };
            var status = await _product.Update(productMapped);
            if (status)
            {
                result.CreateSuccessResult(status.ToString());
                messages.Add("Update Success");
                result.Messages = messages;
                return Ok(result);
            }

            result.CreateFailureResult("Update Failed");
            return BadRequest(result);
        }
        [HttpDelete("{proId}")]
        public async Task<IActionResult> Delete(int proId) {
            var result = new Result<string>();
            var messages = new List<string>();
            var product = await _product.GetByID(proId);
            if (product != null)
            {
                var status = await _product.Delete(product);
                if (status)
                {
                    result.CreateSuccessResult(status.ToString());
                    messages.Add("Delete Success");
                    result.Messages = messages;
                    return Ok(result);
                }

                result.CreateFailureResult("Delete Failed");
                return BadRequest(result);
            }
            result.CreateFailureResult("No Product Found");
            return BadRequest(result);
        }
    }
}
