using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DotnetCoreCrud.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("products")]
        public ActionResult GetAll()
        {
            Console.WriteLine("Get all products");
            try
            {
                var ret = JsonConvert.SerializeObject(_productService.GetAll());
                Console.WriteLine("Get all products [SUCCESS] - {0}", ret.ToString());
                return Ok(ret);
            }
            catch (Exception e)
            {
                Console.WriteLine("Get all products [ERROR] - {0}", e.ToString());
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("product")]
        public ActionResult Add([FromBody] Product product)
        {
            Console.WriteLine("Add product");
            try
            {
                _productService.Add(product);
                Console.WriteLine("[SUCCESS] - Product successfully inserted");
                return Ok("Product successfully inserted");
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - Product insertion error - {0}", e.ToString());
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("product")]
        public ActionResult Update([FromBody] Product product)
        {
            Console.WriteLine("Update product");
            try
            {
                _productService.Update(product);
                Console.WriteLine("[SUCCESS] - Product updated successfully");
                return Ok("Product updated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - Product update error - {0}", e.ToString());
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("product/{guid}")]
        public ActionResult Remove([FromRoute] Guid guid)
        {
            Console.WriteLine("Remove product");
            try
            {
                _productService.Remove(guid);
                Console.WriteLine("[SUCCESS] - Product successfully removed");
                return Ok("Product successfully removed");
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - Product removal error - {0}", e.ToString());
                return StatusCode(500, e.Message);
            }
        }
    }
}
