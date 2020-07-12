using System;
using DotnetCoreCrud.Domain.Entities;
using DotnetCoreCrud.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotnetCoreCrud.Controllers
{
    [ApiController]
    [Route("api")]
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryServive)
        {
            _categoryService = categoryServive;
        }

        [HttpGet]
        [Route("categories")]
        public ActionResult GetAll()
        {
            Console.WriteLine("Get all categories");
            try
            {
                var ret = JsonConvert.SerializeObject(_categoryService.GetAll());
                Console.WriteLine("Get all categories [SUCCESS] - {0}", ret.ToString());
                return Ok(ret);
            }
            catch (Exception e)
            {
                Console.WriteLine("Get all categories [ERROR] - {0}", e.ToString());
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("category")]
        public ActionResult Add([FromBody] Category category)
        {
            Console.WriteLine("Add category");
            try
            {
                _categoryService.Add(category);
                Console.WriteLine("[SUCCESS] - Category successfully inserted");
                return Ok("Category successfully inserted");
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - Category insertion error - {0}", e.ToString());
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("category")]
        public ActionResult Update([FromBody] Category category)
        {
            Console.WriteLine("Update category");
            try
            {
                _categoryService.Update(category);
                Console.WriteLine("[SUCCESS] - Category updated successfully");
                return Ok("Category updated successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - Category update error - {0}", e.ToString());
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("category/{guid}")]
        public ActionResult Remove([FromRoute] Guid guid)
        {
            Console.WriteLine("Remove category");
            try
            {
                _categoryService.Remove(guid);
                Console.WriteLine("[SUCCESS] - Category successfully removed");
                return Ok("Category successfully removed");
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] - Category removal error - {0}", e.ToString());
                return StatusCode(500, e.Message);
            }
        }

    }
}
