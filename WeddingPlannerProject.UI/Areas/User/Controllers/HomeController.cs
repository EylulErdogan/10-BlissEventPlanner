using Microsoft.AspNetCore.Mvc;
using WeddingPlannerProject.Data.Interfaces;

namespace WeddingPlannerProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var products = _unitOfWork.ProductPackage
                .GetAll(includeProps: "Category")
                .Where(x => x.IsActive)
                .ToList();

            return View(products);
        }
    }
}