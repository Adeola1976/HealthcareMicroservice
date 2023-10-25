namespace Hospital.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Hospitals, HospitalForCreationDto>().ReverseMap();
            CreateMap<Hospitals, GetHospitalResponse>().ReverseMap();
        }
    }
}
