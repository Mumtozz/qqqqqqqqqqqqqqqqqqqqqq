using AutoMapper;
using Domain.DTOs.CourseDTO;
using Domain.DTOs.GroupDTO;
using Domain.DTOs.MentorDTO;
using Domain.DTOs.StudentDTO;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Student, AddStudentDto>().ReverseMap();
        CreateMap<Student, GetStudentDto>().ReverseMap();
        CreateMap<Student, UpdateStudentDto>().ReverseMap();
        CreateMap<Mentor,AddMentorDTO>().ReverseMap();
        CreateMap<Mentor,GetMentorDTO>().ReverseMap();
        CreateMap<Mentor,UpdateMentorDTO>().ReverseMap();
        CreateMap<Course,AddCourseDTO>().ReverseMap();
        CreateMap<Course,GetCourseDTO>().ReverseMap();
        CreateMap<Course,UpdateCourseDTO>().ReverseMap();
        CreateMap<Group,AddGroupDTO>().ReverseMap();
        CreateMap<Group,GetGroupDTO>().ReverseMap();
        CreateMap<Group,UpdateGroupDTO>().ReverseMap();
        
        
        
        // //ForMembers
        // CreateMap< Student,GetStudentDto>()
        //     .ForMember(sDto => sDto.FulName, opt => opt.MapFrom(s => $"{s.FirstName} {s.LastName}"))
        //     .ForMember(sDto => sDto.EmailAddress, opt => opt.MapFrom(s =>s.Email));
        //
        // //Reverse map
        // CreateMap<BaseStudentDto,Student>().ReverseMap();
        //
        // // ignore
        // CreateMap<Student, AddStudentDto>()
        //     .ForMember(dest => dest.FirstName, opt => opt.Ignore());


    }   
}