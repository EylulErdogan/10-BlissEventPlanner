using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.UI.Models.ViewModels
{
    public class DashboardViewModel
    {
        public int CategoryCount { get; set; }

        public int ProductPackageCount { get; set; }

        public int ReservationCount { get; set; }

        public int PendingReservationCount { get; set; }

        public int CommentCount { get; set; }

        public int PendingCommentCount { get; set; }

        public int ContactRequestCount { get; set; }

        public int SaleCount { get; set; }

        public decimal TotalSalesAmount { get; set; }

        public List<Reservation>? LastReservations { get; set; }

        public List<Comment>? LastComments { get; set; }
    }
}