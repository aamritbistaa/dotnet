using JWT_Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("GetData")]
        public string GetData()
        {
            return "Authenticated with JWT";
        }

        [HttpGet]
        [Route("Details")]
        public string Details()
        {
            return "Authenticated with JWT";
        }

        [Authorize]
        [HttpPost]
        [Route("AddEmployee")]
        public string AddUser(Users user)
        {
            return "User added with username " + user.Username;
        }
    }
}
