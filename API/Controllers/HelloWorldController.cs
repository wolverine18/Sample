using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Domain.Abstract;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {

        IHelloWorld _helloWorld;

        public HelloWorldController(IHelloWorld helloWorld)
        {
            _helloWorld = helloWorld;
        }

        // GET: api/HelloWorld
        [EnableCors("Presentation")]
        [HttpGet]
        public async Task<string> GetAsync()
        {
            return await _helloWorld.GetHelloWorld();
        }
    }
}
