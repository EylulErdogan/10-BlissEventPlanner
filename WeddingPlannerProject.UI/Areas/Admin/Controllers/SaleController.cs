using Microsoft.AspNetCore.Mvc;
using WeddingPlannerProject.Data.Interfaces;

namespace WeddingPlannerProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SaleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var sales = _unitOfWork.Sale.GetAll(includeProps: "ProductPackage");
            return View(sales);
        }

        public IActionResult Delete(int id)
        {
            var sale = _unitOfWork.Sale.GetFirstOrDefault(x => x.Id == id);

            if (sale == null)
                return NotFound();

            _unitOfWork.Sale.Delete(sale);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}