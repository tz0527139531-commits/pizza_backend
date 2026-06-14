using Microsoft.AspNetCore.Mvc;
using PizzaShopCore.Entities;
using PizzaShopCore.Services;
using PizzaShopCore.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;

        public OrderController(IOrderService order)
        {
            _OrderService = order;
        }


        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderDTO>> Get()
        {
            return Ok(_OrderService.GetList());
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderDTO> Get(int id)
        {
            var a = _OrderService.GetById(id);
            if (a == null)
                return NotFound();
            return Ok(a);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrderDTO o)
        {
            if (o == null)
            {
                return BadRequest();
            }
           await _OrderService.PostOrderAsync(o);

            return CreatedAtAction(nameof(Get), new { id = o.OrderId }, o);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderDTO o)
        {
          await  _OrderService.UpdateOrderAsync(o);

            return NoContent();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = _OrderService.GetById(id);

            if (order == null)
                return NotFound();

            await _OrderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
