using Application.DTOs.Responses;
using Application.Interfaces.ForServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        private readonly ILogger<GroupsController> _logger;

        public GroupsController(IGroupService groupService, ILogger<GroupsController> logger)
        {
            _groupService = groupService;
            _logger = logger;
        }

        [HttpGet("groups")]
        public async Task<IActionResult> GetGroups([FromQuery] int courseId)
        {
            GetGroupsResponse getGroupsResponse = await _groupService.GetGroupsAsync(courseId);

            return Ok(getGroupsResponse);
        }

        //[HttpPost("groups/assign")]
        //public async Task<IActionResult> AddGroup([FromQuery] int courseId)
        //{
        //    GetGroupsResponse getGroupsResponse = await _groupService.AddGroupAsync(courseId);

        //    return Ok(getGroupsResponse);
        //}
    }
}