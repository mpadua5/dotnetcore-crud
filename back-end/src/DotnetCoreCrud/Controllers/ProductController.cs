using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotnetCoreCrud.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductController : Controller
    {
        
        [HttpGet]
        [Route("products")]
        public ActionResult GetAll()
        {
            Console.WriteLine("GOOOL");
            return StatusCode(200, "Olá Mundo");
        }
    }
}
