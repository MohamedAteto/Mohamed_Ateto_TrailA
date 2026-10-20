using AutoMapper;
using Mohamed_Ateto_TrailA.DTOs.ApplicationDTOs;
using Mohamed_Ateto_TrailA.DTOs.AuthDTOs;
using Mohamed_Ateto_TrailA.DTOs.CandidateDTOs;
using Mohamed_Ateto_TrailA.DTOs.CompanyDTOs;
using Mohamed_Ateto_TrailA.DTOs.JobDTOs;
using Mohamed_Ateto_TrailA.Models;

namespace Mohamed_Ateto_TrailA.Mapping
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles() { 
        
            CreateMap<User , RegisterDTO>().ReverseMap();
            CreateMap<User , LoginDTO>().ReverseMap();

            CreateMap<Job,JobDTO>().ReverseMap();

            CreateMap<Application, ApplicationDTO>().ReverseMap();

            CreateMap<Company,CompanyDTO>().ReverseMap();

            CreateMap<CanditateProfile, CandidateDTO>().ReverseMap();
            CreateMap<CanditateProfile, UpdateCandidateProfileDTO>().ReverseMap();
        
        }
    }
}
