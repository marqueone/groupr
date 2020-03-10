using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net.marqueone.groupr.shared.Models;
using net.marqueone.groupr.shared.Services;
using net.marqueone.groupr.shared.ViewModels;

namespace net.marqueone.groupr.webapi.Controllers
{
    [ApiController]
    [Route("_api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<AdminController> _logger;
        private readonly GrouprService _service;

        public AdminController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AdminController> logger, IGrouprService service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _service = (GrouprService)service;
        }

        [HttpPost]
        [Route("remove-user")]
        public async Task<IActionResult> RemoveUser(GroupUser model)
        {
            var results = await _service.RemoveGroupUser(model);
            return Ok(); 
        }

        [HttpPost]
        [Route("rename-group")]
        public async Task<IActionResult> RenameGroup(NewGroupName model)
        {
            var results = await _service.CreateOrUpdateGroup(new UpsertGroup { Name = model.Name, UserId = model.UserId, Id = model.GroupId});
            return Ok();
        }

        [HttpPost]
        [Route("list-users")]
        public async Task<List<ListUser>> ListUsers()
        {
            return await _service.GetUsers();
        }

        [HttpPost]
        [Route("list-groups")]
        public async Task<List<GroupViewModel>> ListGroups()
        {
            var groups = await _service.ListGroups();
            return groups.Select(r => new GroupViewModel { Id = r.Id, Name = r.Name }).ToList();
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
