using AM.Application.Contracts.AccountAgg;
using AM_Domain.AccountAgg;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountApplication _application;

        public AccountsController(IAccountApplication application)
        {
            _application = application;
        }


        [HttpPost("RegisterAccount")]
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


        [HttpPost("LoginAccount")]
        public ActionResult<string> Login(AccountViewModel command)
        {
            bool operation = _application.Login(command);

            if (operation)
            {
                return Ok("operation was successful");
            }
            else
            {
                return BadRequest("username or password is not correct");
            }
            
        }
    }
}
