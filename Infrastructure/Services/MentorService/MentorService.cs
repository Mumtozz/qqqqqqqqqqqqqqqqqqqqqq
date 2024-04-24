using System.Data.Common;
using AutoMapper;
using Domain.DTOs.MentorDTO;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.MentorService;

public class MentorService : IMentorService
{
    
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public MentorService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<string>> CreateMentorAsync(AddMentorDTO mentor)
    {
         try
        {
            var existingMentor = await _context.Mentors.FirstOrDefaultAsync(x => x.FirstName == mentor.FirstName);
            if (existingMentor != null)
                return new Response<string>(System.Net.HttpStatusCode.BadRequest, "Mentor already exists");
            var mapped = _mapper.Map<Mentor>(mentor);

            await _context.Mentors.AddAsync(mapped);
            await _context.SaveChangesAsync();

            return new Response<string>("Successfully created a new Mentor");
        }
        catch (Exception e)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteMentorAsync(int id)
    {
        try
        {
            var mentor = await _context.Students.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (mentor == 0)
                return new Response<bool>(System.Net.HttpStatusCode.BadRequest, "mentor not found");

            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(System.Net.HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<GetMentorDTO>> GetMentorByIdAsync(int id)
    {
         try
        {
            var men = await _context.Mentors.FirstOrDefaultAsync(x => x.Id == id);
            if (men == null)
                return new Response<GetMentorDTO>(System.Net.HttpStatusCode.BadRequest, "Mentor not found");
            var mapped = _mapper.Map<GetMentorDTO>(men);
            return new Response<GetMentorDTO>(mapped);
        }
        catch (Exception e)
        {
            return new Response<GetMentorDTO>(System.Net.HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<List<GetMentorDTO>>> GetMentorsAsync()
    {
         try
        {
            var men = await _context.Students.ToListAsync();
            var mapped = _mapper.Map<List<GetMentorDTO>>(men);
            return new Response<List<GetMentorDTO>>(mapped);
        }
        catch (DbException dbEx)
        {
            return new Response<List<GetMentorDTO>>(System.Net.HttpStatusCode.InternalServerError, dbEx.Message);
        }
        catch (Exception ex)
        {
            return new Response<List<GetMentorDTO>>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    public async Task<Response<string>> UpdateMentorAsync(UpdateMentorDTO mentor)
    {
        
        try
        {
            var mappedMentor = _mapper.Map<Mentor>(mentor);
            _context.Mentors.Update(mappedMentor);
            var update= await _context.SaveChangesAsync();
            if(update==0)  return new Response<string>(System.Net.HttpStatusCode.BadRequest, "Mentor not found");
            return new Response<string>("Mentor updated successfully");
        }
        catch (Exception e)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, e.Message);
        }
    }

}
