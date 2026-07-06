using Microsoft.AspNetCore.Mvc;

namespace WeddingPlannerProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
