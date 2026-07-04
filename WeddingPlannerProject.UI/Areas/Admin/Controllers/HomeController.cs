using Microsoft.AspNetCore.Mvc;
using WeddingPlannerProject.Data.Interfaces;
using WeddingPlannerProject.UI.Models.ViewModels;

namespace WeddingPlannerProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var reservations = _unitOfWork.Reservation.GetAll(includeProps: "ProductPackage").ToList();
            var comments = _unitOfWork.Comment.GetAll(includeProps: "ProductPackage").ToList();
            var sales = _unitOfWork.Sale.GetAll().ToList();

            DashboardViewModel model = new DashboardViewModel()
            {
                CategoryCount = _unitOfWork.Category.GetAll().Count(),
                ProductPackageCount = _unitOfWork.ProductPackage.GetAll().Count(),

                ReservationCount = reservations.Count(),
                PendingReservationCount = reservations.Count(x => x.IsConfirmed == false),

                CommentCount = comments.Count(),
                PendingCommentCount = comments.Count(x => x.IsApproved == false),

                ContactRequestCount = _unitOfWork.ContactRequest.GetAll().Count(),

                SaleCount = sales.Count(),
                TotalSalesAmount = sales.Sum(x => x.TotalPrice),

                LastReservations = reservations
                    .OrderByDescending(x => x.Id)
                    .Take(5)
                    .ToList(),

                LastComments = comments
                    .OrderByDescending(x => x.Id)
                    .Take(5)
                    .ToList()
            };

            return View(model);
        }
    }
}