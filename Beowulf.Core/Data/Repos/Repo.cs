using Microsoft.EntityFrameworkCore;

namespace Beowulf.Core.Data.Repos
{
    public class Repo<T>(BeowulfDbContext context) : IRepo<T> where T : class
    {
        private BeowulfDbContext context = context;
        private DbSet<T> Set => context.Set<T>();

        public async Task Create(T entity)
        {
            await Set.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            Set.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            Set.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T?> Get(Guid id)
        {
            return await Set.FindAsync(id);
        }

        public Task<List<T>> Get(Func<T, bool> condition)
        {
            return Task.FromResult(Set.Where(condition).ToList());
        }
    }
}
