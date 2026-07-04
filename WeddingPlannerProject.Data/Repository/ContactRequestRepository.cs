using WeddingPlannerProject.Data.Interfaces;
using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.Data.Repository
{
    public class ContactRequestRepository : Repository<ContactRequest>, IContactRequestRepository
    {
        private readonly AppDbContext _context;

        public ContactRequestRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(ContactRequest contactRequest)
        {
            _context.ContactRequests.Update(contactRequest);
        }
    }
}