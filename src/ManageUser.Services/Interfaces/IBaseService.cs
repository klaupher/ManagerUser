using System.Linq.Expressions;

namespace ManageUser.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : Domain.Entities.BaseClass
    {
        Task<TEntity> CreateAsync(TEntity TEntity);

        Task<TEntity> UpdateAsync(TEntity TEntity);

        Task RemoveAsync(int id);

        Task<TEntity> GetAsync(int id);

        Task<List<TEntity>> GetAllAsync();

        Task<IList<TEntity>> FindByPredicateAsync(Expression<Func<TEntity, bool>> entity);
    }
}
