using Microsoft.AspNetCore.Identity;

namespace WeddingPlannerProject.Model
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}