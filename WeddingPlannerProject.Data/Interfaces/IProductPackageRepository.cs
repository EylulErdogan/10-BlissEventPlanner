using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.Data.Interfaces
{
    public interface IProductPackageRepository : IRepository<ProductPackage>
    {
        void Update(ProductPackage productPackage);
    }
}