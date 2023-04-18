using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConsultancyApp.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryDescriptionService _categoryDescriptionService;
        private ICategoryService _categoryService;

        public CategoryController(ICategoryDescriptionService categoryDescriptionService, ICategoryService categoryService)
        {
            _categoryDescriptionService = categoryDescriptionService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
