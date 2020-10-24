using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace shopLocalApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {

        }

        [HttpPost("Signup")]
        public async Task<ActionResult> Signup()
        {
            throw new NotImplementedException();
        }


        [HttpPost("Login")]
        public async Task<ActionResult> Login()
        {
            throw new NotImplementedException();
        }

        [HttpPost("Logout")]
        public async Task<ActionResult> Logout()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("DeleteAccount/{accountId}")]
        public async Task<ActionResult> DeleteAccount(string accountId)
        {
            throw new NotImplementedException();
        }
    }
}
