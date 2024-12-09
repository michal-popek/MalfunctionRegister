namespace MalfunctionRegisterApp.DataTransferObjects
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
    }
}
