using AutoMapper;
using Hospital.Domain;
using Hospital.Domain.DTOs.Request;
using Hospital.Domain.DTOs.Response;

namespace Hospital.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hospitals, HospitalForCreationDto>().ReverseMap();
            CreateMap<Hospitals, GetHospitalResponse>().ReverseMap();
            CreateMap<UserHospitalForCreationDto, HospitalForCreationDto>().ReverseMap();
        }
    }
}
