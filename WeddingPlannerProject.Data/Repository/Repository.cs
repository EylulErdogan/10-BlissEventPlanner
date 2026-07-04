using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WeddingPlannerProject.Data.Interfaces;

namespace WeddingPlannerProject.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        internal DbSet<T> dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll(string? includeProps = null)
        {
            IQueryable<T> query = dbSet;

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var item in includeProps.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return query.ToList();
        }

        public T GetFirstOrDefault(
            Expression<Func<T, bool>> filter,
            string? includeProps = null
        )
        {
            IQueryable<T> query = dbSet.Where(filter);

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var item in includeProps.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            return query.FirstOrDefault();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}