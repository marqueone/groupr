using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using net.marqueone.groupr.shared.Data;
using net.marqueone.groupr.shared.Models.Exceptions;
using net.marqueone.groupr.shared.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace net.marqueone.groupr.shared.Services
{
    public class GrouprService : IGrouprService
    {
        private readonly ILogger<GrouprService> _logger;
        private readonly GrouprContext _context;

        public GrouprService(GrouprContext context, ILogger<GrouprService> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Group> CreateOrUpdateGroup(UpsertGroup model)
        {
            //-- make sure that the data is good 
            //-- throw an exception if there are values missing
            if (string.IsNullOrWhiteSpace(model.Name) || string.IsNullOrWhiteSpace(model.UserId))
            {
                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    throw new ArgumentNullException(model.Name, message: "Group name cannot be empty");
                }

                if (string.IsNullOrWhiteSpace(model.UserId))
                {
                    throw new ArgumentNullException(model.UserId, message: "Must provide a valid user id");
                }
            }

            //-- upsert the new group
            if (model.Id == -1)
            {
                //-- group names should be unique
                var normalizedName = model.Name.ToLower();
                if (await _context.Groups.AnyAsync(g => g.NormalizedName == normalizedName))
                {
                    throw new GrouprException($"Unable to add group; group already exists; {model.Name}")
                    {
                        Task = "UpsertGroup",
                        Parameters = { { "action", "create" }, { "model", JsonConvert.SerializeObject(model) } }
                    };
                }
                var group = new Group { Name = model.Name, NormalizedName = model.Name.ToLower(), CreatedBy = model.UserId, Created = DateTimeOffset.Now, Members = new List<GroupMember>() };
                group.Members.Add(new GroupMember { UserId = model.UserId, IsAdmin = true });
                var results = await _context.Groups.AddAsync(group);

                await _context.SaveChangesAsync();
                return results.Entity;
            }
            else
            {
                //-- make sure there is an group available, if there isn't then throw
                //-- an exception
                if (!await _context.Groups.AnyAsync(r => r.Id == model.Id))
                {
                    throw new GrouprException($"Unable to update group; group id does not exist: {model.Id}")
                    {
                        Task = "UpsertGroup",
                        Parameters = { { "action", "update" }, { "group", JsonConvert.SerializeObject(model) } }
                    };
                }

                var group = await _context.Groups.FirstOrDefaultAsync(r => r.Id == model.Id);
                if (group == null)
                {
                    throw new GrouprException($"Unable to update group; group id does not exist: {model.Id}")
                    {
                        Task = "UpsertGroup",
                        Parameters = { { "action", "update" }, { "group", JsonConvert.SerializeObject(model) } }
                    };
                }

                //-- update the group
                group.Name = model.Name;
                group.Updated = DateTimeOffset.Now;
                group.UpdatedBy = model.UserId;

                await _context.SaveChangesAsync();
                return group;
            }
        }

        public async Task<Group> JoinGroup(JoinGroup model)
        {
            if (model.GroupId == 0)
            {
                throw new ArgumentException("Must provide a valid group id", "model.GroupId");
            }

            if (string.IsNullOrWhiteSpace(model.UserId))
            {
                throw new ArgumentNullException(model.UserId, message: "Must provide a valid user id");
            }

            //-- make sure there is an group available, if there isn't then throw
            //-- an exception
            if (!await _context.Groups.AnyAsync(r => r.Id == model.GroupId))
            {
                throw new GrouprException($"Unable to join group; group id does not exist: {model.GroupId}")
                {
                    Task = "JoinGroup",
                    Parameters = { { "group", JsonConvert.SerializeObject(model) } }
                };
            }

            var group = await _context.Groups.FirstOrDefaultAsync(r => r.Id == model.GroupId);
            if (group == null)
            {
                throw new GrouprException($"Unable to join group; group id does not exist: {model.GroupId}")
                {
                    Task = "JoinGroup",
                    Parameters = { { "group", JsonConvert.SerializeObject(model) } }
                };
            }

            // group.Members.Add(new GroupMember { UserId = model.UserId });
            var result = await _context.GroupMemebers.AddAsync(new GroupMember { GroupId = model.GroupId, UserId = model.UserId });
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task<List<Group>> Search(string query)
        {
            return !string.IsNullOrWhiteSpace(query)
                ? await _context.Groups.Where(r => r.Name.Contains(query)).ToListAsync()
                : await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetGroupByName(string name)
        {
            return await _context.Groups
                            .AsNoTracking()
                            .FirstOrDefaultAsync(r => r.NormalizedName == name.ToLower());
        }
    }
}