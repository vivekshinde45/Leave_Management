using Leave_Management.Contracts;
using Leave_Management.Data;

namespace Leave_Management.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveAllocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveAllocation entity)
        {
            if (_db != null && entity != null)
            {
                _db.LeaveAllocations.Add(entity);
                return Save();
            }
            return false;
        }

        public bool Delete(LeaveAllocation entity)
        {
            if (_db != null && entity != null)
            {
                _db.LeaveAllocations.Remove(entity);
                return Save();
            }
            return false;
        }

        public ICollection<LeaveAllocation> FindAll()
        {
            var leaveAllocations = new List<LeaveAllocation>();
            if (_db != null)
            {
                leaveAllocations = _db.LeaveAllocations.ToList();
            }
            return leaveAllocations;
        }

        public LeaveAllocation FindById(int id)
        {
            var leaveAllocation = new LeaveAllocation();
            if(_db != null)
            {
                leaveAllocation = _db.LeaveAllocations.FirstOrDefault(x => x.Id == id);
            }
            return leaveAllocation;
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

        public bool Update(LeaveAllocation entity)
        {
            if (_db != null && entity != null)
            {
                _db.LeaveAllocations.Update(entity);
                return Save();
            }
            return false;
        }
    }
}
