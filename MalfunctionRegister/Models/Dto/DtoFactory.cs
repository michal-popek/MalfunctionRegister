namespace MalfunctionRegister.Models.Dto
{
    public class DtoFactory
    {
        public MalfunctionReportDto CreateMalfunctionReportDto(
            int id,
            string title,
            string comment,
            string author,
            ReportState state)
        {
            return new MalfunctionReportDto(id, title, comment, author, state);
        }

        public AddMalfunctionReportDto CreateAddMalfunctionReportDto(
            string title,
            string comment,
            string author)
        {
            return new AddMalfunctionReportDto(title, comment, author);
        }

        public ModifyMalfunctionReportDto CreateModifyMalfunctionReportDto(
            int id,
            string title,
            string comment,
            string author)
        {
            return new ModifyMalfunctionReportDto(id, title, comment, author);
        }

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
