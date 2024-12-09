using AutoMapper;
using MalfunctionRegisterApp.ApiService.Data;
using MalfunctionRegisterApp.ApiService.Models;
using MalfunctionRegisterApp.ApiService.Models.Dto;
using MalfunctionRegisterApp.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace MalfunctionRegisterApp.ApiService.Controllers
{
    [Route("api/MalfunctionRegister")]
    [ApiController]
    public class MalfunctionRegisterController : ControllerBase
    {
        private readonly MalfunctionReportsRepository _reportsRepository;
        private readonly IMapper _mapper;
        private DtoFactory _dtoFactory = new DtoFactory();
        private ModelsFactory _modelsFactory;

        public MalfunctionRegisterController(ApplicationDbContext db, IMapper mapper)
        {
            _modelsFactory = new ModelsFactory();
            _reportsRepository = new MalfunctionReportsRepository(_modelsFactory, db);
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MalfunctionReportDto>))]
        public ActionResult<IEnumerable<MalfunctionReportDto>> GetReports()
        {
            var list = _mapper.Map<List<MalfunctionReportDto>>(_reportsRepository.GetReports());
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MalfunctionReportDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MalfunctionReportDto> GetReport(int id)
        {
            if (id < 0)
                return BadRequest();
            var report = _reportsRepository.GetReport(id);
            if (report == null)
                return NotFound();
            return Ok(_mapper.Map<MalfunctionReportDto>(report));
        }

        [HttpPost]
        public ActionResult<MalfunctionReportDto> CreateReport([FromBody] AddMalfunctionReportDto report)
        {
            if (report == null)
                return BadRequest();

            var newReport = _mapper.Map<AddMalfunctionReport>(report);
            var addedReport = _reportsRepository.Add(newReport);
            return Ok(_mapper.Map<MalfunctionReportDto>(addedReport));
        }

        [HttpDelete("{id:int}", Name = "DeleteReport")]
        public IActionResult DeleteReport(int id)
        {
            if (id == 0)
                return BadRequest();
            var report = _reportsRepository.GetReport(id);
            if (report == null)
                return NotFound();
            _reportsRepository.Remove(report);
            return NoContent();
        }
    }
}