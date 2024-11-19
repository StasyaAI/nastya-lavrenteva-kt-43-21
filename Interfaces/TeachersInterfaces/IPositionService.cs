using _1_лабораторная.Database;
using _1_лабораторная.Filters.TeacherFilters;
using _1_лабораторная.Models;
using System.Threading;

namespace _1_лабораторная.Interfaces.TeachersInterfaces
{

    public interface IPositionService
    {
        public Position GetPositionById(int id);
        public Position GetPositionByName(string name);

    }

    public class PositionService : IPositionService
    {
        private readonly TeacherDbContext _dbContext;

        public PositionService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Position GetPositionById(int positionId)
        {
            return _dbContext.Positions.Where(d => d.PositionId == positionId).FirstOrDefault();
        }
        public Position GetPositionByName(string positionName)
        {
            return _dbContext.Positions.Where(w => w.Name == positionName).FirstOrDefault();



        }
    }
}
