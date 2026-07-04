namespace WeddingPlannerProject.Model
{
    public class Sale
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int ProductPackageId { get; set; }
        public ProductPackage ProductPackage { get; set; }

        public DateTime SaleDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}