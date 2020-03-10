using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net.marqueone.groupr.shared.Models;

namespace net.marqueone.groupr.webapi.Controllers
{
    [ApiController]
    [Route("_api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AdminController> _logger;

        public AdminController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AdminController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        
        [HttpPost]
        [Route("add-user")]
        public async Task AddUser(NewUser model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email
            };

            await _userManager.CreateAsync(user);

        }
    }
}
