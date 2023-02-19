using MyResumeSite.Data;
using MyResumeSite.DataLayer.Repositories;
using MyResumeSite.Utilities;

namespace MyResumeSite.DataLayer.Services
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public string AdminID()
        {
            string roleID = _context.Roles.Where(n => n.Name == SD.AdminEndUser).First().Id;
            string UserID = _context.UserRoles.Where(n => n.RoleId == roleID).First().UserId;
            return UserID;
        }
    }
}
