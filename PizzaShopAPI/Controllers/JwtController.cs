using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaShopService;

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
            if (login.UserName == "Tamar" && login.Password == "1234")
            {
                var token = _jwtService.GenerateToken(login.UserName);
                return Ok(token);
            }
            return Unauthorized();
        }

        public class LoginModel
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}

