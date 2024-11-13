using _1_лабораторная.Database;
using _1_лабораторная.Filters.TeacherFilters;
using _1_лабораторная.Models;
using Microsoft.EntityFrameworkCore;

namespace _1_лабораторная.Interfaces.TeachersInterfaces
{
    public interface ITeacherService
    {
        public Task<Teacher> AddTeacher(Teacher teacher);
        public bool TeacherExists(int teacherId);
        public bool UpdateTeacher(Teacher teacher);
        public bool DeleteTeacher(Teacher teacher);
    }

    public class TeacherService : ITeacherService
    {
        private readonly TeacherDbContext _dbContext;

        public TeacherService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            _dbContext.Add(teacher);
            await _dbContext.SaveChangesAsync();
            return teacher;
        }

        public bool DeleteTeacher(Teacher teacher)
        {
            _dbContext.Remove(teacher);
            return _dbContext.SaveChanges() > 0;
        }

        public bool TeacherExists(int teacherId)
        {
            return _dbContext.Teachers.Any(t => t.TeacherId == teacherId);
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            _dbContext.Update(teacher);
            return _dbContext.SaveChanges() > 0;
        }
    }
}