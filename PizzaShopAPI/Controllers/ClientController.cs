using Microsoft.AspNetCore.Mvc;
using PizzaShopCore.Entities;
using PizzaShopCore.Services;
using PizzaShopCore.DTOs;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _ClientService;
   
        public ClientController(IClientService client)
        {
            _ClientService = client;
           
        }


        // GET: api/<ClientController>
        [HttpGet]
        //JWT
        [Authorize]
        public IEnumerable<ClientDTO> Get()//
        {
            return _ClientService.GetList();
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult<ClientDTO> Get(int id)
        {
            var a = _ClientService.GetById(id);
            if (a == null)
                return NotFound();
            return Ok(a);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult<ClientDTO>> Post([FromBody] ClientDTO c)
        {
            if (c == null)
            {
                return BadRequest();
            }
           
           await _ClientService.PostClientAsync(c);

            return CreatedAtAction(nameof(Get), new { id = c.Id }, c);
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public async  Task<IActionResult> Put(int id, [FromBody] ClientDTO c)
        {
           await _ClientService.UpdateClientAsync(c);

            return NoContent();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _ClientService.GetById(id);

            if (client == null)
                return NotFound();

            await _ClientService.DeleteClientAsync(id);
            return NoContent();
        }
    }
}
