using Domain.DTOs.GroupDTO;
using Domain.Responses;

namespace Infrastructure.Services.GroupService;

public interface IGroupService
{
    
    Task<Response<List<GetGroupDTO>>> GetGroupsAsync();
    Task<Response<GetGroupDTO>> GetGroupByIdAsync(int id);
    Task<Response<string>> CreateGroupAsync(AddGroupDTO group);
    Task<Response<string>> UpdateGroupAsync(UpdateGroupDTO group);
    Task<Response<bool>> DeleteGroupAsync(int id);
   
}
