namespace WeddingPlannerProject.Model
{
    public class Reservation
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Phone { get; set; }

        public DateTime WeddingDate { get; set; }

        public int ProductPackageId { get; set; }
        public ProductPackage ProductPackage { get; set; }

        public string Note { get; set; }
        public bool IsConfirmed { get; set; }
    }
}