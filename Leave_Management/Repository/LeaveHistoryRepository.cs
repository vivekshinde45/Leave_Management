using Leave_Management.Contracts;
using Leave_Management.Data;

namespace Leave_Management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveHistory entity)
        {
            if (_db != null && entity != null)
            {
                _db.LeaveHistories.Add(entity);
                return Save();
            }
            return false;
        }

        public bool Delete(LeaveHistory entity)
        {
            if (_db != null && entity != null)
            {
                _db.LeaveHistories.Remove(entity);
                return Save();
            }
            return false;
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var leaveHistories = new List<LeaveHistory>();
            if (_db != null)
            {
                leaveHistories = _db.LeaveHistories.ToList();
            }
            return leaveHistories;
        }

        public LeaveHistory FindById(int id)
        {
            var leaveHistory = new LeaveHistory();
            if (_db != null)
            {
                leaveHistory = _db.LeaveHistories.FirstOrDefault(x => x.Id == id);
            }
            return leaveHistory;
        }

        public bool Save()
        {
            if (_db != null)
            {
                var change = _db.SaveChanges();
                return change > 0;
            }
            return false;
        }

        public bool Update(LeaveHistory entity)
        {
            if (_db != null && entity != null)
            {
                _db.LeaveHistories.Update(entity);
                return Save();
            }
            return false;
        }
    }
}
