using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client.Events;

namespace DesafioNatalino.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // POST api/values
        [HttpPost]
        public void Post([FromBody]RequestMessage message)
        {
            var processor = new Processor();
            processor.Test(message);
        }

    }
}
