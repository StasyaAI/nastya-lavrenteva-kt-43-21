﻿using _1_лабораторная.Dto;
using _1_лабораторная.Filters.TeacherFilters;
using _1_лабораторная.Interfaces.TeachersInterfaces;
using _1_лабораторная.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1_лабораторная.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ILogger<TeachersController> _logger;
        private readonly ITeacherFilterInterfaceService _teacherFilterService;
        private readonly ITeacherService _teacherService;
        private readonly IPositionService _positionService;
        private readonly IDepartmentService _departmentService;

        public TeachersController(
            ILogger<TeachersController> logger, 
            ITeacherService studentService,
            ITeacherFilterInterfaceService teacherFilterService, 
            ITeacherService teacherService,
            IPositionService positionService,
            IDepartmentService departmentService
            )
        {
            _logger = logger;
            _teacherFilterService = teacherFilterService;
            _teacherService = teacherService;
            _positionService = positionService;
            _departmentService = departmentService;
        }

        [HttpPost("GetTeachersByDepartmentAsync")]
        public async Task<IActionResult> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherFilterService.GetTeachersByDepartmentAsync(filter, cancellationToken);

            return Ok(teachers);
        }
        [HttpPost("GetTeachersByDepartmentNameAsync")]
        public async Task<IActionResult> GetTeachersByDepartmentNameAsync(DeparrtmentNameFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherFilterService.GetTeachersByDepartmentNameAsync(filter, cancellationToken);

            return Ok(teachers);
        }

        [HttpPost("GetTeachersByPositionAsync")]
        public async Task<IActionResult> GetTeachersByPositionAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherFilterService.GetTeachersByPositionAsync(filter, cancellationToken);

            return Ok(teachers);
        }

        [HttpPost("GetTeachersByNameAsync")]
        public async Task<IActionResult> GetTeachersByNameAsync(TeacherDataFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherFilterService.GetTeachersByDataAsync(filter, cancellationToken);

            return Ok(teachers);
        }

        [HttpPost("add")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddTeacher(TeacherDto teacher)
        {
            Position position = _positionService.GetPositionById(teacher.positionId);
            Department department = _departmentService.GetDepartmentById(teacher.departmentId);

            Teacher newTeacher = new Teacher { 
                FirstName = teacher.FirstName, 
                LastName = teacher.LastName, 
                MiddleName = teacher.MiddleName 
            };

            newTeacher.PositionId = teacher.positionId;
            newTeacher.Position = position;
            newTeacher.DepartmentId = teacher.departmentId;
            newTeacher.Department = department;

            return Ok(await _teacherService.AddTeacher(newTeacher));
        }


        [HttpPut("{teacherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTeacher(int teacherId, TeacherDto updatedTeacher)
        {
            if (updatedTeacher == null)
                return BadRequest(ModelState);

            if (!_teacherService.TeacherExists(teacherId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            Position position = _positionService.GetPositionById(updatedTeacher.positionId);
            Department department = _departmentService.GetDepartmentById(updatedTeacher.departmentId);

            Teacher teacher = new Teacher
            {
                Department = department,
                Position = position,
                FirstName = updatedTeacher.FirstName,
                LastName = updatedTeacher.LastName,
                MiddleName = updatedTeacher.MiddleName,
                DepartmentId = updatedTeacher.departmentId,
                PositionId = updatedTeacher.positionId
            };

            if (!_teacherService.UpdateTeacher(teacher))
            {
                ModelState.AddModelError("", "Something went wrong updating teacher");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{teacherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOwner(int teacherId)
        {
            if (!_teacherService.TeacherExists(teacherId))
            {
                return NotFound();
            }

            var teacherToDelete = _teacherFilterService.GetTeacherById(teacherId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_teacherService.DeleteTeacher(teacherToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting teacher");
            }

            return NoContent();
        }
    }
}