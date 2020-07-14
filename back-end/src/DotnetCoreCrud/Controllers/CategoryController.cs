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
    public class CategoryController : Controller
    {

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryServive)
        {
            _categoryService = categoryServive;
        }

        [HttpGet]
        [Route("categories")]
        [Authorize]
        public ActionResult GetAll()
        {
            Console.WriteLine("Get all categories");
            try
            {
                var ret = JsonConvert.SerializeObject(_categoryService.GetAll());
                Console.WriteLine("Get all categories [SUCCESS] - {0}", ret.ToString());
                return Ok(JsonConvert.DeserializeObject(ret.ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine("Get all categories [ERROR] - {0}", e.ToString());
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("category")]
        [Authorize]
        public ActionResult Add([FromBody] Category category)
        {
            Console.WriteLine("Add category");
            var ret = _categoryService.Add(category);
            if (ret.Code == 1)
                return Ok(ret);
            else
                return StatusCode(500, ret);
        }

        [HttpPut]
        [Route("category")]
        [Authorize]
        public ActionResult Update([FromBody] Category category)
        {
            Console.WriteLine("Update category");
            var ret = _categoryService.Update(category);
            if (ret.Code == 1)
                return Ok(ret);
            else
                return StatusCode(500, ret);
        }

        [HttpDelete]
        [Route("category/{guid}")]
        [Authorize]
        public ActionResult Remove([FromRoute] Guid guid)
        {
            Console.WriteLine("Remove category");
            var ret = _categoryService.Remove(guid);
            if (ret.Code == 1)
                return Ok(ret);
            else
                return StatusCode(500, ret);
        }

    }
}
