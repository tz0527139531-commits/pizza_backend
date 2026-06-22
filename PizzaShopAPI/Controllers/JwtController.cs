using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShopService;
using PizzaShopCore.Entities;

namespace PizzaShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {

        private readonly JwtService _jwtService;

        public JwtController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // כאן נבצע אימות משתמש מול מסד הנתונים

            // דוגמה לאימות
            var c =_jwtService.login(login);
            if (c!=null)
            {
                var token = _jwtService.GenerateToken(login.UserName);
                return Ok(token);
            }
            return Unauthorized();
        }

       
    }
}

