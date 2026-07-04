using Microsoft.AspNetCore.Mvc;
using WeddingPlannerProject.Data.Interfaces;

namespace WeddingPlannerProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var comments = _unitOfWork.Comment.GetAll(includeProps: "ProductPackage");
            return View(comments);
        }

        public IActionResult Approve(int id)
        {
            var comment = _unitOfWork.Comment.GetFirstOrDefault(x => x.Id == id);

            if (comment == null)
                return NotFound();

            comment.IsApproved = true;

            _unitOfWork.Comment.Update(comment);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var comment = _unitOfWork.Comment.GetFirstOrDefault(x => x.Id == id);

            if (comment == null)
                return NotFound();

            _unitOfWork.Comment.Delete(comment);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}