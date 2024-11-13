using _1_лабораторная.Database;
using _1_лабораторная.Filters.TeacherFilters;
using _1_лабораторная.Models;

namespace _1_лабораторная.Interfaces.TeachersInterfaces
{
  public interface IDepartmentService
    {
        public Task<Department> DeleteDepartment(TeacherDepartmentFilter department, CancellationToken cancellationToken);
        public Department GetDepartmentById(int id);
        public ICollection<Department> GetDepartment();
        public Task<Department> AddDepartment(Department department);
        public bool DepartmentExists(int deparmentId);
        public bool UpdateDepartment(Department department);
        public bool DeleteDepartment(Department department);
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly TeacherDbContext _dbContext;

        public DepartmentService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Department> GetDepartment()
        {
            return _dbContext.Department.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _dbContext.Department.Where(d => d.DepartmentId == id).FirstOrDefault();
        }

        public Task<Department> DeleteDepartment(TeacherDepartmentFilter department, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Department> AddDepartment(Department department)
        {
            _dbContext.Add(department);
            await _dbContext.SaveChangesAsync();
            return department;
        }

        public bool DepartmentExists(int deparmentId)
        {
            return _dbContext.Department.Any(d => d.DepartmentId == deparmentId);
        }

        public bool UpdateDepartment(Department department)
        {
            _dbContext.Update(department);
            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteDepartment(Department department)
        {
            _dbContext.Remove(department);
            return _dbContext.SaveChanges() > 0;
        }
    }
}