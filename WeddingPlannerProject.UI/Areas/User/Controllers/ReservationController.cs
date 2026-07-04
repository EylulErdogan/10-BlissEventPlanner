using Microsoft.AspNetCore.Mvc;
using WeddingPlannerProject.Data.Interfaces;
using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.UI.Areas.User.Controllers
{
    [Area("User")]
    public class ReservationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Create(int id)
        {
            var product = _unitOfWork.ProductPackage.GetFirstOrDefault(x => x.Id == id && x.IsActive);

            if (product == null)
                return NotFound();

            Reservation reservation = new Reservation
            {
                ProductPackageId = product.Id,
                WeddingDate = DateTime.Now
            };

            ViewBag.ProductName = product.Name;
            ViewBag.Price = product.Price;

            return View(reservation);
        }

        [HttpPost]
        public IActionResult Create(Reservation reservation)
        {
            reservation.Id = 0;
            reservation.IsConfirmed = false;

            _unitOfWork.Reservation.Add(reservation);
            _unitOfWork.Save();

            TempData["success"] = "Rezervasyon talebiniz başarıyla alındı.";

            return RedirectToAction("Index", "Home", new { area = "User" });
        }
    }
}