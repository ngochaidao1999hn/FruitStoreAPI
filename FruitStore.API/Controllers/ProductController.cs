using FruitStore.Business.Interfaces;
using FruitStore.Core.Models;
using FruitStore.DAL.Enums;
using FruitStore.DAL.Models;
using FruitStore.DTOS.ProductDTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FruitStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusiness _product;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IProductBusiness product, IWebHostEnvironment hostEnvironment)
        {
            _product = product;
            webHostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> Insert([FromForm] CreateDTO createRequest) {
            var result = new Result<string>();
            var messages = new List<string>();
            var path = await Upload(createRequest.Img);


            var productMapped = new Fruit()
            {
                FruitName = createRequest.FruitName,
                Price = createRequest.Price,
                Descrip = createRequest.Descrip,
                ImpDate = DateTime.Now,
                Quantity = createRequest.Quantity,
                IsImported = createRequest.IsImported,
                Img =path,
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
        public async Task<IActionResult> Update([FromForm] UpdateDTO updateRequest) {
            var result = new Result<string>();
            var messages = new List<string>();
            var productMapped = new Fruit()
            {
                Id = updateRequest.Id,
                FruitName = updateRequest.FruitName,
                Price = updateRequest.Price,
                Descrip = updateRequest.Descrip,
                ImpDate = updateRequest.ImpDate,
                Quantity = updateRequest.Quantity,
                IsImported = updateRequest.IsImported,
                Img = (updateRequest.Img!=null)?await Upload(updateRequest.Img):null,
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
        private async Task<string> Upload(IFormFile file) {
            string fName = file.FileName;
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
            string path = Path.Combine(uploadsFolder, file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return "Images/"+fName;
        }
    }
}
