using System.Net;
using Domain.DTOs.GroupDTO;
using Domain.Responses;
using Infrastructure.Services.GroupService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
      private readonly IGroupService _group;

    public GroupController(IGroupService group)
    {
        _group = group;
    }

    [HttpGet("get-Groups")]
    public async Task<Response<List<GetGroupDTO>>> GetGroupsAsync()
    {
        return await _group.GetGroupsAsync();
    }
    [HttpGet("{GroupId:int}")]
    public async Task<Response<GetGroupDTO>> GetGroupByIdAsync(int GroupId)
    {
        return await _group.GetGroupByIdAsync(GroupId);
    }
    
    [HttpPost("create-Group")]
    public async Task<Response<string>> AddGroupAsync(AddGroupDTO groupDto)
    {
        return await _group.CreateGroupAsync(groupDto);
    }
    
    [HttpPut("update-Group")]
    public async Task<Response<string>> UpdateGroupAsync(UpdateGroupDTO groupDto)
    {
        return await _group.UpdateGroupAsync(groupDto);
    }
    
    [HttpDelete("{GroupId:int}")]
    public async Task<Response<bool>> DeleteGroupAsync(int groupId)
    {
        return await _group.DeleteGroupAsync(groupId);
    }


    
}
