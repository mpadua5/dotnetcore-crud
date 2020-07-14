using System;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize]
        public ActionResult GetAll()
        {
            Console.WriteLine("Get all products");
            try
            {
                var ret = JsonConvert.SerializeObject(_productService.GetAll());
                Console.WriteLine("Get all products [SUCCESS] - {0}", ret.ToString());
                return Ok(JsonConvert.DeserializeObject(ret.ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("Get all products [ERROR] - {0}", e.ToString());
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("product")]
        [Authorize]
        public ActionResult Add([FromBody] Product product)
        {
            Console.WriteLine("Add product");
            var ret = _productService.Add(product);
            if (ret.Code == 1)
                return Ok(ret);
            else
                return StatusCode(500, ret);
        }

        [HttpPut]
        [Route("product")]
        [Authorize]
        public ActionResult Update([FromBody] Product product)
        {
            Console.WriteLine("Update product");
            var ret =_productService.Update(product);
            if (ret.Code == 1)
                return Ok(ret);
            else
                return StatusCode(500, ret);
        }

        [HttpDelete]
        [Route("product/{guid}")]
        [Authorize]
        public ActionResult Remove([FromRoute] Guid guid)
        {
            Console.WriteLine("Remove product");
            var ret = _productService.Remove(guid);
            if (ret.Code == 1)
                return Ok(ret);
            else
                return StatusCode(500, ret);
        }
    }
}
