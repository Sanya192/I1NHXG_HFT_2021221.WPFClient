using Microsoft.AspNetCore.Mvc;
using VegyesBolt.API.Helper;
using VegyesBolt.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VegyesBolt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MegyeController : ControllerBase
    {
        // GET: api/<MegyeController>
        [HttpGet]
        public IEnumerable<Megyek> Get()
        {
            return Shared.Worker.GetMegyek();
        }

        // GET api/<MegyeController>/5
        [HttpGet("{id}")]
        public Megyek Get(int id)
        {
            return Shared.Worker.GetMegye(id);
        }

        // POST api/<MegyeController>
        [HttpPost]
        public void Post([FromBody] Megyek megye)
        {
            Shared.Worker.UpdateMegye(megye);
        }

        // PUT api/<MegyeController>/5
        [HttpPut()]
        public void Put([FromBody] Megyek value)
        {
            Shared.Worker.CreateMegye(value);
        }

        // DELETE api/<MegyeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Shared.Worker.DeleteMegyek(new Megyek() { Id = id });
        }
    }
}
