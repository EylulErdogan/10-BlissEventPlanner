using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.Data.Interfaces
{
    public interface ISaleRepository : IRepository<Sale>
    {
        void Update(Sale sale);
    }
}