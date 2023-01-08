using AutoMapper;
using University.BLL.Dtos;
using University.DAL.Entities;

namespace University.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentCreateDto>().ReverseMap();            
        }
    }
}
