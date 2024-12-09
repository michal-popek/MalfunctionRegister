using MalfunctionRegisterApp.ApiService.Models;

namespace MalfunctionRegisterApp.ApiService.Data
{
    public class MalfunctionReportsRepository
    {
        //private readonly List<MalfunctionReport> _reportList = new List<MalfunctionReport>();
        private readonly ModelsFactory _factory;
        private readonly ApplicationDbContext _db;

        public MalfunctionReportsRepository(ModelsFactory factory, ApplicationDbContext db)
        {
            _factory = factory;
            _db = db;
        }

        public IEnumerable<MalfunctionReport> GetReports()
        {
            return _db.Reports.ToList();
        }

        public MalfunctionReport GetReport(int id)
        {
            return _db.Reports.FirstOrDefault(x => x.Id == id);
        }

        public MalfunctionReport Add(AddMalfunctionReport report)
        {
            if (report == null)
                return null;
            var newReport = _factory.CreateMalfunctionReport(report.Title, report.Comment, report.Author);
            _db.Add(newReport);
            _db.SaveChanges();
            return newReport;
        }

        public void Remove(int id)
        {
            var report = GetReport(id);
            Remove(report);
        }

        public void Remove(MalfunctionReport report)
        {
            if (report == null)
                return;

            _db.Remove(report);
            _db.SaveChanges();
        }
    }
}
