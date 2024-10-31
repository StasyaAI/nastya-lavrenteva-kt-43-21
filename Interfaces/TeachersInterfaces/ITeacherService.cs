using _1_лабораторная.Database;
using _1_лабораторная.Filters.TeacherFilters;
using _1_лабораторная.Models;
using Microsoft.EntityFrameworkCore;

namespace _1_лабораторная.Interfaces.TeachersInterfaces
{
    public interface ITeacherService
    {
        public Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken);
    }

    public class TeacherService : ITeacherService
    {
        private readonly TeacherDbContext _dbContext;

        public TeacherService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Teacher[]> GetTeachersByDepartmentAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var teacher = await _dbContext.Set<Teacher>().Where(w => w.Department.DepartmentName == filter.DepartmentName).ToArrayAsync(cancellationToken);

            return teacher;
        }
    }
}