using Microsoft.AspNetCore.Mvc;

namespace stefanini_e_counter.Controllers
{
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        public FormController()
        {

        }

        [HttpGet]
        public string Get()
        {
            return "test";
        }
    }
}