using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeddingPlannerProject.Data.Interfaces;
using WeddingPlannerProject.Model;
using WeddingPlannerProject.UI.Models.ViewModels;

namespace WeddingPlannerProject.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductPackageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductPackageController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var list = _unitOfWork.ProductPackage.GetAll(includeProps: "Category");
            return View(list);
        }

        public IActionResult Crup(int? id = 0)
        {
            ProductPackageViewModel productVM = new ProductPackageViewModel()
            {
                ProductPackage = new ProductPackage(),
                CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.Id.ToString()
                })
            };

            if (id == null || id <= 0)
            {
                return View(productVM);
            }

            productVM.ProductPackage = _unitOfWork.ProductPackage.GetFirstOrDefault(x => x.Id == id);

            if (productVM.ProductPackage == null)
            {
                return NotFound();
            }

            return View(productVM);
        }

        [HttpPost]
        public IActionResult Crup(ProductPackageViewModel productVM, IFormFile file)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwwRootPath, @"img\productpackages");
                var extension = Path.GetExtension(file.FileName);

                if (!Directory.Exists(uploadRoot))
                {
                    Directory.CreateDirectory(uploadRoot);
                }

                if (productVM.ProductPackage.ImageUrl != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, productVM.ProductPackage.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                productVM.ProductPackage.ImageUrl = @"\img\productpackages\" + fileName + extension;
            }
            if (productVM.ProductPackage.Id <= 0)
            {
                productVM.ProductPackage.IsActive = true;
                _unitOfWork.ProductPackage.Add(productVM.ProductPackage);
            }
            else
            {
                _unitOfWork.ProductPackage.Update(productVM.ProductPackage);
            }

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.ProductPackage.GetFirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            if (product.ImageUrl != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                var oldImagePath = Path.Combine(wwwRootPath, product.ImageUrl.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _unitOfWork.ProductPackage.Delete(product);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}