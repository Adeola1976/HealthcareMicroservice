using AutoMapper;
using User.Domain;
using User.Domain.DTOs.Request;
using User.Domain.DTOs.Response;

namespace User.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserHospital, UserHospitalForCreationDto>().ReverseMap();
            CreateMap<UserHospital, GetUserHospitalResponse>().ReverseMap();
        }
    }
}
