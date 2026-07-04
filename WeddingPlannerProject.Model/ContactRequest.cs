namespace WeddingPlannerProject.Model
{
    public class ContactRequest
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Phone { get; set; }

        public DateTime RequestDate { get; set; }
        public bool IsCalled { get; set; }
    }
}