using Microsoft.EntityFrameworkCore;
using MyResumeSite.Data;
using MyResumeSite.DataLayer.Repositories;
using MyResumeSite.Models.ViewModels;

namespace MyResumeSite.DataLayer.Services
{
    public class ValidationRepository : IValidationRepository
    {
        private readonly ApplicationDbContext _context;
        public ValidationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> isAnyRole()
        {
            return await _context.Roles.AnyAsync();
        }

        public async Task<bool> isAnyUserRole()
        {
            return await _context.UserRoles.AnyAsync();
        }
    }
}
