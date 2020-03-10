using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using net.marqueone.groupr.shared.Models;

namespace net.marqueone.groupr.webapi.Controllers
{
    [ApiController]
    [Route("_api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;

        public GroupController(ILogger<GroupController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("join")]
        public IActionResult Join(JoinGroup model)
        {
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateGroup model)
        {
            return Ok();
        }

        [HttpPost]
        [Route("search")]
        public IActionResult Search(GroupSearchQuery model)
        {
            return Ok();
        }
    }
}
