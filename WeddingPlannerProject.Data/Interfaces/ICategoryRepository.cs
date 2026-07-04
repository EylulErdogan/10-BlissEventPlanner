using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.Data.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}