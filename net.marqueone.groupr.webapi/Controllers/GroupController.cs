using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using net.marqueone.groupr.shared.Models;
using net.marqueone.groupr.shared.ViewModels;
using net.marqueone.groupr.shared.Services;
using System;
using net.marqueone.groupr.shared.Models.Exceptions;

namespace net.marqueone.groupr.webapi.Controllers
{
    [ApiController]
    [Route("_api/[controller]")]
    public class GroupController : Controller
    {
        private readonly ILogger<GroupController> _logger;
        private readonly GrouprService _service;

        public GroupController(ILogger<GroupController> logger, IGrouprService service)
        {
            _logger = logger;
            _service = (GrouprService)service;
        }

        [HttpPost]
        [Route("join")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Join(GroupUser model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.JoinGroup(model);
                return Ok(true);
            }
            catch (GrouprException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create(CreateGroup model)
        {
            if (!ModelState.IsValid)
            {

            }
            var result = await _service.CreateOrUpdateGroup(new UpsertGroup { Name = model.Name, UserId = model.UserId, Description = model.Description });
            var viewModel = new GroupViewModel
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description
            };

            return Ok(viewModel);
        }

        [HttpPost]
        [Route("search")]
        [ProducesResponseType(200)]
        public async Task<List<GroupViewModel>> Search(GroupSearchQuery model)
        {
            var results = await _service.Search(model.Query);
            return results.Select(r => new GroupViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();
        }

        [HttpGet]
        [Route("my-groups")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<List<GroupViewModel>> MyGroups()
        {
            var groups = await _service.ListGroups();
            return groups.Select(r => new GroupViewModel { Id = r.Id, Name = r.Name, Description = r.Description }).ToList();
        }
    }
}
