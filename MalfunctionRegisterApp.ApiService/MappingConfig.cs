using AutoMapper;
using MalfunctionRegisterApp.ApiService.Models;
using MalfunctionRegisterApp.DataTransferObjects;

namespace MalfunctionRegisterApp.ApiService
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<MalfunctionReport, MalfunctionReportDto>().ReverseMap();
            CreateMap<AddMalfunctionReport, AddMalfunctionReportDto>().ReverseMap();
        }
    }
}
