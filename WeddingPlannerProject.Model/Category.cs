namespace WeddingPlannerProject.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<ProductPackage> ProductPackages { get; set; }
    }
}
