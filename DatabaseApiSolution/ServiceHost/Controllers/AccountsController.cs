using AM.Application.Contracts.AccountAgg;
using AM_Domain.AccountAgg;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<Account> Register(AccountViewModel command)
        {
            _application.Register(command);
            return Ok();
        }


        [HttpPost("LoginAccount")]
        public ActionResult<string> Login(AccountViewModel command)
        {
            var check = _application.Login(command);
            return Ok(check);
        }
    }
}
