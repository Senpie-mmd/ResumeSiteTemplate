using MyResumeSite.Models;
using System.Linq.Expressions;

namespace MyResumeSite.DataLayer.Repositories
{
    public interface ISectionTitleRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class
    {
        int SectionID(Expression<Func<AdminResumeSectionTitle, bool>> where);
    }
}
