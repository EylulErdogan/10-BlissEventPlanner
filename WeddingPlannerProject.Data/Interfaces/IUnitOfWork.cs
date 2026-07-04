namespace WeddingPlannerProject.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductPackageRepository ProductPackage { get; }
        ICommentRepository Comment { get; }
        IReservationRepository Reservation { get; }
        IContactRequestRepository ContactRequest { get; }
        ISaleRepository Sale { get; }

        void Save();
    }
}