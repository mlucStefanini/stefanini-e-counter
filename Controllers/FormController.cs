using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace stefanini_e_counter.Controllers
{
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "test";
        }
    }
}