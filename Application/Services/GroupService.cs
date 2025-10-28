using Application.DTOs.Responses;
using Application.DTOs.Secondary;
using Application.Interfaces.ForRepositories;
using Application.Interfaces.ForServices;
using Domain;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class GroupService : IGroupService
    {
        IGroupRepositorie _groupRepositorie;

        ILogger<GroupService> _logger;

        public GroupService(ILogger<GroupService> logger, IGroupRepositorie groupRepositorie)
        {
            _logger = logger;
            _groupRepositorie = groupRepositorie;
        }

        public async Task AddStudentInGroupAsync(Student student)
        {
            await _groupRepositorie.AddStudentInGroupAsync(student);
        }

        public async Task<GetGroupsResponse> GetGroupsAsync(int courseId)
        {
            List<ParticularGroup> particularGroups = await _groupRepositorie.GetGroupsByCourseIdAsync(courseId);

            GetGroupsResponse getGroupsResponse = new GetGroupsResponse()
            {
                Id = courseId,
                Groups = particularGroups
            };
            
            return getGroupsResponse;
        }

        //public async Task<GetGroupsResponse> AddGroupsAsync(int courseId)
        //{
        //    await _groupRepositorie.AddGroupsAsync(int courseId);

        //    List<ParticularGroup> particularGroups = await _groupRepositorie.GetGroupsByCourseIdAsync(courseId);

        //    GetGroupsResponse getGroupsResponse = new GetGroupsResponse()
        //    {
        //        Id = courseId,
        //        Groups = particularGroups
        //    };

        //    return getGroupsResponse;
        //}
    }
}