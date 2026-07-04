using Microsoft.AspNetCore.Mvc;
using WeddingPlannerProject.Data.Interfaces;

namespace WeddingPlannerProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class ShopListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShopListController(IUnitOfWork unitOfWork)
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
        public IActionResult Detail(int id)
        {
            var product = _unitOfWork.ProductPackage
                .GetFirstOrDefault(x => x.Id == id && x.IsActive, includeProps: "Category");

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}