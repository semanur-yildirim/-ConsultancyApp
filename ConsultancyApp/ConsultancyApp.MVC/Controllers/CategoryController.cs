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
        private IPsychologistService _psychologistService;

        public CategoryController(ICategoryDescriptionService categoryDescriptionService, ICategoryService categoryService, IPsychologistService psychologistService)
        {
            _categoryDescriptionService = categoryDescriptionService;
            _categoryService = categoryService;
            _psychologistService = psychologistService;
        }

        public async Task<IActionResult> CategoryDetails(string categoryurl)
        {
           Category categories = await _categoryService.GetCategoryDetailsByUrlAsync(categoryurl);
           List<Psychologist> psychologist = await _psychologistService.GetPsychologistsByCategoriesAsync(categories.Id);
            CategoryDescriptionModel categoryDescriptionModel = new CategoryDescriptionModel();
            categoryDescriptionModel.Summary = categories.CategoryDescription.Summary;
            categoryDescriptionModel.What= categories.CategoryDescription.What;
            categoryDescriptionModel.How = categories.CategoryDescription.How;
            categoryDescriptionModel.ForWho = categories.CategoryDescription.ForWho;
            categoryDescriptionModel.Purpose = categories.CategoryDescription.Purpose;
            categoryDescriptionModel.HowLong = categories.CategoryDescription.HowLong;
            categoryDescriptionModel.PositiveEffect = categories.CategoryDescription.PositiveEffect;
            categoryDescriptionModel.CategoryName = categories.Name;
            categoryDescriptionModel.Psychologist= psychologist;
            return View(categoryDescriptionModel);
        }

    }
}
