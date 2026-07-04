using Microsoft.AspNetCore.Mvc;
using WeddingPlannerProject.Data.Interfaces;
using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var list = _unitOfWork.Category.GetAll();
            return View(list);
        }

        public IActionResult Crup(int? id = 0)
        {
            if (id == null || id <= 0)
                return View(new Category());

            var category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Crup(Category category)
        {
            if (category.Id <= 0)
                _unitOfWork.Category.Add(category);
            else
                _unitOfWork.Category.Update(category);

            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);

            if (category == null)
                return NotFound();

            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}