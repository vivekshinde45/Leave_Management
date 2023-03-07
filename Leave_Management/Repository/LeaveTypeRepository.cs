using Leave_Management.Contracts;
using Leave_Management.Data;

namespace Leave_Management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveType entity)
        {
            if(_db != null && entity != null)
            {
                _db.LeaveTypes.Add(entity);
                return Save();
            }
            return false;
        }

        public bool Delete(LeaveType entity)
        {
            if (_db != null && entity != null)
            {
                _db.LeaveTypes.Remove(entity);
                return Save();
            }
            return false;
        }

        public ICollection<LeaveType> FindAll()
        {
            var leaveTypes = new List<LeaveType>();
            if(_db != null)
            {
                leaveTypes = _db.LeaveTypes.ToList();
            }
            return leaveTypes;
        }

        public LeaveType FindById(int id)
        {
            var leaveType = new LeaveType();
            if(_db != null)
            {
                leaveType = _db.LeaveTypes.FirstOrDefault(x => x.Id == id);
            }
            return leaveType;
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool isExist(int id)
        {
            var exists = _db.LeaveTypes.Any(x => x.Id == id);
            return exists;
        }

        public bool Save()
        {
            if( _db != null)
            {
                var change = _db.SaveChanges();
                return change > 0;
            }
            return false;
        }

        public bool Update(LeaveType entity)
        {
            if (_db != null && entity != null)
            {
                _db.LeaveTypes.Update(entity);
                return Save();
            }
            return false;
        }
    }
}
