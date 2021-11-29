using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QTBWebBackend.Models;
using QTBWebBackend.Services;

namespace QTBWebBackend.Controllers
{
  
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("api/login/authenticate")]
        
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            //var temp = collection;
            var response = _loginService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
            
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _loginService.GetAll();
            return Ok(users);
        }
    }
}
