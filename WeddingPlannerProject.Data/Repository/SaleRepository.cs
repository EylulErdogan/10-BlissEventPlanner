using WeddingPlannerProject.Data.Interfaces;
using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.Data.Repository
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        private readonly AppDbContext _context;

        public SaleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Sale sale)
        {
            _context.Sales.Update(sale);
        }
    }
}