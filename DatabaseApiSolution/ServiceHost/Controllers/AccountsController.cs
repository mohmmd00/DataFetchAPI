using AM.Application.Contracts.AccountAgg;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountApplication _application;


        public AccountsController(IAccountApplication application , IConfiguration configuration)
        {
            _application = application;
        }





        [HttpPost("Register")]
        public ActionResult<string> CreateNewAccount(AccountViewModel command)
        {
            bool operation = _application.Register(command);

            if (operation)
            {
                return Ok("operation was successful");
            }
            else
            {
                return BadRequest($"{command.UserName} is already exist");
            }
            
        }
        [HttpPost("Login")]
        public ActionResult<string> Login(AccountViewModel command)
        {
            string token = _application.Login(command);
            

            if (!string.IsNullOrWhiteSpace(token))
            {
                return Ok(token);
            }
            else
            {
                return BadRequest("username or password is not correct");
            }
            
        }
    }
}
