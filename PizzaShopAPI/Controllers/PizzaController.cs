using Microsoft.AspNetCore.Mvc;
using PizzaShopCore.DTOs;
using PizzaShopCore.Entities;
using PizzaShopCore.Services;
using PizzaShopData;
using PizzaShopService;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _PizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _PizzaService = pizzaService;
        }


        // GET: api/<PizzaController>
        [HttpGet]
        public ActionResult<IEnumerable<Pizza>> Get()
        {
            return Ok(_PizzaService.GetList());
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var a = _PizzaService.GetById(id);
           if (a==null)
                return NotFound();
           return Ok(a);
        }

        // POST api/<PizzaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Pizza p)
        {
            if (p == null)
            {
                return BadRequest();
            }
           await _PizzaService.PostPizzaAsync(p);

            return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
        }

        // PUT api/<PizzaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Pizza p)
        {
            await _PizzaService.UpdatePizzaAsync(p);
            
            return NoContent();
        }

        // DELETE api/<PizzaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //בודקת האם הפיצה קיימת בכלל במאגר הפיצות
            var pizza = _PizzaService.GetById(id);

            if (pizza == null)
                return NotFound();

           await _PizzaService.DeletePizzaAsync(id);
            return NoContent();
        }
    }
}
