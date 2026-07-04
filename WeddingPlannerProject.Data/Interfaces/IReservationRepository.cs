using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.Data.Interfaces
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        void Update(Reservation reservation);
    }
}