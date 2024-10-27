using AutoMapper;
using MalfunctionRegister.Models;
using MalfunctionRegister.Models.Dto;

namespace MalfunctionRegister
{
    public class MappingConfig: Profile
    {
        public MappingConfig() 
        {
            CreateMap<MalfunctionReport, MalfunctionReportDto>().ReverseMap();
            CreateMap<AddMalfunctionReport, AddMalfunctionReportDto>().ReverseMap();
        }
    }
}
