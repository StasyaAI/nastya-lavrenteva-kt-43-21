using _1_лабораторная.Database;
using _1_лабораторная.Models;

namespace _1_лабораторная.Interfaces.TeachersInterfaces
{

    public interface IPositionService
    {
        public Position GetPositionById(int id);
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
    }
}
