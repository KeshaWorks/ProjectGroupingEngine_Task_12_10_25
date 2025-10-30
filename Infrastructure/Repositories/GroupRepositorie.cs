using Application.Interfaces.ForRepositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class GroupRepositorie : IGroupRepositorie
    {
        private readonly AppDbContext _appDbContext;

        private readonly ILogger<GroupRepositorie> _logger;

        public GroupRepositorie(AppDbContext appDbContext, ILogger<GroupRepositorie> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<int> AddGroupAsync(Group group)
        {
            await _appDbContext.Groups.AddAsync(group);

            await _appDbContext.SaveChangesAsync();

            return group.Id;
        }

        public async Task<List<Group>> GetGroupsByCourseIdAsync(int courseId)
        {
            List<Group> groups = await _appDbContext.Groups.ToListAsync();

            List<Group> gropusByCourseId = groups.FindAll(x => x.CourseId == courseId);

            return gropusByCourseId;
        }

        public async Task<List<Group>> GetAllGroupsAsync()
        {
            List<Group> groups = await _appDbContext.Groups.ToListAsync();

            return groups;
        }
    }
}                                                          