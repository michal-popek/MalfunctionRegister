namespace MalfunctionRegisterApp.DataTransferObjects
{
    public class ModifyMalfunctionReportDto : AddMalfunctionReportDto
    {
        public ModifyMalfunctionReportDto(int id, string title, string comment, string author) : base(title, comment, author)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
