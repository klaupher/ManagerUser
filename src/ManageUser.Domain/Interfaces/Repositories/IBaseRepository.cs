using ManageUser.Domain.Entities;

namespace ManageUser.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseClass
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task RemoveAsync(long id);

        Task<TEntity> GetAsync(long id);

        Task<List<TEntity>> GetAllAsync();
    }
}
