namespace Beowulf.Core.Data.Repos
{
    public interface IRepo<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T?> Get(Guid id);
        Task<List<T>> Get(Func<T, bool> condition);
    }
}
