using MalfunctionRegisterApp.DataTransferObjects;

namespace MalfunctionRegisterApp.ApiModel
{
    public class MalfunctionReport : ModifyMalfunctionReport
    {
        public DateTime TimeOfRegister { get; set; }
        public DateTime DateOfLastModifications { get; set; }

        public ReportState State { get; set; }
    }
}
