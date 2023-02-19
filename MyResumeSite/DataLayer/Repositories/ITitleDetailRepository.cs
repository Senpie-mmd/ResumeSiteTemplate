using MyResumeSite.Models;

namespace MyResumeSite.DataLayer.Repositories
{
    public interface ITitleDetailRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class
    {
        Task<List<SectionTitleDetail>> TitleDetail();
    }
}
