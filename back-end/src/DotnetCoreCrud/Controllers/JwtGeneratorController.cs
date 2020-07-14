using DotnetCoreCrud.Factories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreCrud.Controllers
{
    [ApiController]
    [Route("api")]
    public class JwtGeneratorController : Controller
    {
        [HttpGet]
        [Route("jwt")]
        [AllowAnonymous]
        public ActionResult GetJwt()
        {
            JwtFactory jwt = new JwtFactory();
            return StatusCode(200, jwt);
        }
    }
}
