namespace WeddingPlannerProject.Model
{
    public class ProductPackage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsPackage { get; set; }

        public bool IsActive { get; set; }
        public bool IsPopular { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<Comment>? Comments { get; set; }

        public List<Reservation>? Reservations { get; set; }
    }
}