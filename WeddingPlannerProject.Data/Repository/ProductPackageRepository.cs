using WeddingPlannerProject.Data.Interfaces;
using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.Data.Repository
{
    public class ProductPackageRepository : Repository<ProductPackage>, IProductPackageRepository
    {
        private readonly AppDbContext _context;

        public ProductPackageRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(ProductPackage productPackage)
        {
            _context.ProductPackages.Update(productPackage);
        }
    }
}