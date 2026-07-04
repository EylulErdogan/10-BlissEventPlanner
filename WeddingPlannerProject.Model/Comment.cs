namespace WeddingPlannerProject.Model
{
    public class Comment
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Message { get; set; }

        public int ProductPackageId { get; set; }
        public ProductPackage ProductPackage { get; set; }

        public DateTime CommentDate { get; set; }
        public bool IsApproved { get; set; }
    }
}