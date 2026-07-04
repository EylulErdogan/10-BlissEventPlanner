using Microsoft.AspNetCore.Mvc.Rendering;
using WeddingPlannerProject.Model;

namespace WeddingPlannerProject.UI.Models.ViewModels
{
    public class ProductPackageViewModel
    {
        public ProductPackage ProductPackage { get; set; }

        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}