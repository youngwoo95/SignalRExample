using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace BlazorApp1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempController : ControllerBase
    {

        public TempController()
        {
            
        }

        [HttpGet]
        [Route("select")]
        public string Get()
        {
           

            return "123124";
        }

        [HttpPost]
        [Route("insert")]
        public string Post([FromBody]string mr)
        {
            Console.WriteLine(mr);
            return mr;
        }

    }
}
