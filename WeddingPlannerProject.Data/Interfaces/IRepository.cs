using System.Linq.Expressions;

namespace WeddingPlannerProject.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProps = null);

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter,
            string? includeProps = null
        );
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}