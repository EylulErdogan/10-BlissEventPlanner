using Microsoft.AspNetCore.Mvc;
using WeddingPlannerProject.Data.Interfaces;
using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var reservations = _unitOfWork.Reservation.GetAll(includeProps: "ProductPackage");
            return View(reservations);
        }

        public IActionResult Confirm(int id)
        {
            var reservation = _unitOfWork.Reservation
                .GetFirstOrDefault(x => x.Id == id, includeProps: "ProductPackage");

            if (reservation == null)
                return NotFound();

            reservation.IsConfirmed = true;

            Sale sale = new Sale
            {
                ProductPackageId = reservation.ProductPackageId,
                SaleDate = DateTime.Now,
                TotalPrice = reservation.ProductPackage.Price,
                UserId = "Rezervasyon"
            };

            _unitOfWork.Reservation.Update(reservation);
            _unitOfWork.Sale.Add(sale);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var reservation = _unitOfWork.Reservation.GetFirstOrDefault(x => x.Id == id);

            if (reservation == null)
                return NotFound();

            _unitOfWork.Reservation.Delete(reservation);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}