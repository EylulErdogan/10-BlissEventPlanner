using WeddingPlannerProject.Data.Interfaces;

namespace WeddingPlannerProject.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public ICategoryRepository Category { get; private set; }
        public IProductPackageRepository ProductPackage { get; private set; }
        public ICommentRepository Comment { get; private set; }
        public IReservationRepository Reservation { get; private set; }
        public IContactRequestRepository ContactRequest { get; private set; }
        public ISaleRepository Sale { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Category = new CategoryRepository(_context);
            ProductPackage = new ProductPackageRepository(_context);
            Comment = new CommentRepository(_context);
            Reservation = new ReservationRepository(_context);
            ContactRequest = new ContactRequestRepository(_context);
            Sale = new SaleRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}