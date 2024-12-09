namespace MalfunctionRegisterApp.DataTransferObjects
{
    public class AddMalfunctionReportDto
    {
        public AddMalfunctionReportDto(string title, string comment, string author)
        {
            Title = title;
            Comment = comment;
            Author = author;
        }

        public string Title { get; set; }
        public string Comment { get; set; }
        public string Author { get; set; }
    }
}
