using _1_лабораторная.Filters.TeacherFilters;
using _1_лабораторная.Interfaces.TeachersInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace _1_лабораторная.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ILogger<TeachersController> _logger;
        private readonly ITeacherFilterInterfaceService _teacherService;

        public TeachersController(ILogger<TeachersController> logger, ITeacherService studentService, ITeacherFilterInterfaceService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpPost("GetTeachersByDepartmentAsync")]
        public async Task<IActionResult> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersByDepartmentAsync(filter, cancellationToken);

            return Ok(teachers);
        }
    }
}