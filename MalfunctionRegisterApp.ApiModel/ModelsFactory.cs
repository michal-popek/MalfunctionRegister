using MalfunctionRegisterApp.DataTransferObjects;

namespace MalfunctionRegisterApp.ApiModel
{
    public class ModelsFactory
    {
        public AddMalfunctionReport CreateAddMalfunctionReport(AddMalfunctionReportDto dto)
        {
            return new AddMalfunctionReport()
            {
                Title = dto.Title,
                Author = dto.Author,
                Comment = dto.Comment
            };
        }

        public MalfunctionReport CreateMalfunctionReport(
            string title,
            string comment,
            string author)
        {
            var currentTime = DateTime.Now;
            return new MalfunctionReport()
            {
                Id = 0,
                Title = title,
                Comment = comment,
                Author = author,
                TimeOfRegister = currentTime,
                DateOfLastModifications = currentTime,
                State = ReportState.Created
            };
        }

        public MalfunctionReport CreateMalfunctionReport(
            MalfunctionReportDto dto)
        {
            var currentTime = DateTime.Now;
            return new MalfunctionReport()
            {
                Id = 0,
                Title = dto.Title,
                Comment = dto.Comment,
                Author = dto.Author,
                TimeOfRegister = currentTime,
                DateOfLastModifications = currentTime,
                State = ReportState.Created
            };
        }
    }
}
