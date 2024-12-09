using MalfunctionRegisterApp.DataTransferObjects;

namespace MalfunctionRegisterApp.ApiService.Models.Dto
{
    internal class ModelToDtoConverter
    {
        public MalfunctionReportDto CreateMalfunctionReportDto(
            MalfunctionReport report)
        {
            return new MalfunctionReportDto(report.Id, report.Title, report.Comment, report.Author, report.State);
        }

        public AddMalfunctionReportDto CreateAddMalfunctionReportDto(
            MalfunctionReport report)
        {
            return new AddMalfunctionReportDto(report.Title, report.Comment, report.Author);
        }

        public ModifyMalfunctionReportDto CreateModifyMalfunctionReportDto(
            MalfunctionReport report)
        {
            return new ModifyMalfunctionReportDto(report.Id, report.Title, report.Comment, report.Author);
        }
    }
}