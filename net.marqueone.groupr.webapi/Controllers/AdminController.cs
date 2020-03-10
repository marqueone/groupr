using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace net.marqueone.groupr.webapi.Controllers
{
    [ApiController]
    [Route("_api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("remove-user")]
        public IActionResult RemoveUser()
        {
            return Ok();
        }

        [HttpPost]
        [Route("rename-group")]
        public IActionResult RenameGroup()
        {
            return Ok();
        }

        [HttpPost]
        [Route("list-users")]
        public IActionResult ListUsers()
        {
            return Ok();
        }

        [HttpPost]
        [Route("list-groups")]
        public IActionResult ListGroups()
        {
            return Ok();
        }
        
    }
}
