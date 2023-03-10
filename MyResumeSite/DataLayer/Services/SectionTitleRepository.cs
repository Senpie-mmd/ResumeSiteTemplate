using Microsoft.EntityFrameworkCore;
using MyResumeSite.Data;
using MyResumeSite.DataLayer.Repositories;
using MyResumeSite.Models;
using System.Linq.Expressions;

namespace MyResumeSite.DataLayer.Services
{
    public class SectionTitleRepository<TEntity> : ISectionTitleRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entity;

        public SectionTitleRepository(ApplicationDbContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> Where = null)
        {
            IQueryable<TEntity> query = _entity;
            if (Where != null)
            {
                query = query.Where(Where);
            }
            return await query.CountAsync();
        }

        public void Delete(TEntity entity)
        {
            _entity.Remove(entity);
        }

        public void Delete(object ID)
        {
            var item = GetByID(ID);
            Delete(item);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> Where = null)
        {
            IQueryable<TEntity> query = _entity;
            if (Where != null)
            {
                query = query.Where(Where);
            }
            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByID(object ID)
        {
            return await _entity.FindAsync(ID);
        }

        public void Insert(TEntity entity)
        {
            _entity.Add(entity);
        }

        public int SectionID(Expression<Func<AdminResumeSectionTitle, bool>> where)
        {
            return _context.AdminResumeSectionTitles.First(where)
                .ID;
        }

        public void Update(TEntity entity)
        {
            _entity.Update(entity);
        }
    }
}
