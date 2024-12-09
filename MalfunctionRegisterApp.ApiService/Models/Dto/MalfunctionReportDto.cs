using MalfunctionRegister.Models.Dto;

namespace MalfunctionRegisterApp.ApiService.Models.Dto
{
    public class MalfunctionReportDto : ModifyMalfunctionReportDto
    {
        public MalfunctionReportDto(int id, string title, string comment, string author, ReportState state) : base(id, title, comment, author)
        {
            State = state;
        }

        public ReportState State { get; set; }
    }
}
