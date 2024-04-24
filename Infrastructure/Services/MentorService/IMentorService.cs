using Domain.DTOs.MentorDTO;
using Domain.Responses;

namespace Infrastructure.Services.MentorService;

public interface IMentorService
{
    
    Task<Response<List<GetMentorDTO>>> GetMentorsAsync();
    Task<Response<GetMentorDTO>> GetMentorByIdAsync(int id);
    Task<Response<string>> CreateMentorAsync(AddMentorDTO mentor);
    Task<Response<string>> UpdateMentorAsync(UpdateMentorDTO mentor);
    Task<Response<bool>> DeleteMentorAsync(int id);
}
