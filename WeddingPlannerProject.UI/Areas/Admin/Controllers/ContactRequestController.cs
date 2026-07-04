using Microsoft.AspNetCore.Mvc;
using WeddingPlannerProject.Data.Interfaces;

namespace WeddingPlannerProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactRequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactRequestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var requests = _unitOfWork.ContactRequest.GetAll();
            return View(requests);
        }
        public IActionResult MarkAsCalled(int id)
        {
            var request = _unitOfWork.ContactRequest.GetFirstOrDefault(x => x.Id == id);

            if (request == null)
                return NotFound();

            request.IsCalled = true;

            _unitOfWork.ContactRequest.Update(request);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var request = _unitOfWork.ContactRequest.GetFirstOrDefault(x => x.Id == id);

            if (request == null)
                return NotFound();

            _unitOfWork.ContactRequest.Delete(request);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}