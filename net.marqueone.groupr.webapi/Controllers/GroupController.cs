using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using net.marqueone.groupr.shared.Models;
using net.marqueone.groupr.shared.ViewModels;
using net.marqueone.groupr.shared.Services;

namespace net.marqueone.groupr.webapi.Controllers
{
    [ApiController]
    [Route("_api/[controller]")]
    public class GroupController : ControllerBase
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
        public async Task<bool> Join(JoinGroup model)
        {
            var result = await _service.JoinGroup(model);
            return true;
        }

        [HttpPost]
        [Route("create")]
        public async Task<GroupViewModel> Create(CreateGroup model)
        {
            var result = await _service.CreateOrUpdateGroup(new UpsertGroup { Name = model.Name, UserId = model.UserId });
            return new GroupViewModel
            {
                Id = result.Id,
                Name = result.Name
            };
        }

        [HttpPost]
        [Route("search")]
        public async Task<List<GroupViewModel>> Search(GroupSearchQuery model)
        {
            var results = await _service.Search(model.Query);
            return results.Select(r => new GroupViewModel
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();
        }
    }
}
