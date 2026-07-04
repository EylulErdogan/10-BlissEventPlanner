using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.Data.Interfaces
{
    public interface IContactRequestRepository : IRepository<ContactRequest>
    {
        void Update(ContactRequest contactRequest);
    }
}