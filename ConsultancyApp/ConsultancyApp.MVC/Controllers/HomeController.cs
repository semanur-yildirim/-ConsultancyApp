using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsultancyApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IPsychologistService _psychologistService;
        private ICategoryService _categoryService;
        private IPsychologistDescriptionService _psychologistDescriptionService;
        private ICategoryDescriptionService _categoryDescriptionService;

        public HomeController(IPsychologistService psychologistService, ICategoryService categoryService, IPsychologistDescriptionService psychologistDescriptionService, ICategoryDescriptionService categoryDescriptionService)
        {
            _psychologistService = psychologistService;
            _categoryService = categoryService;
            _psychologistDescriptionService = psychologistDescriptionService;
            _categoryDescriptionService = categoryDescriptionService;
        }

        public async Task<IActionResult> Index()
        {
            List<Psychologist> psychologists = await _psychologistService.GetAllPsychologistDataAsync(true);
            List<Category> categories=await _categoryService.GetAllCategoriesAsync(true);

            List<PsychologistModel> psychologistModelList = new List<PsychologistModel>();
            psychologistModelList = psychologists.Select(p => new PsychologistModel
            {
                Id= p.Id,
                Name= p.Name,
                CreatedDate=p.CreatedDate,
                ModifiedDate=p.ModifiedDate,
                Price=p.Price,
                Gender=p.Gender,
                Image=p.Image,
                categories=p.PsychologistCategory.Select(pc=>pc.Category).ToList(),
            }).ToList();
            List<CategoriesModel> categoriesModelList = new List<CategoriesModel>();
            categoriesModelList = categories.Select(c => new CategoriesModel
            {
                Id= c.Id,
                IsApproved=c.IsApproved,
                CreatedDate=c.CreatedDate,
                ModifiedDate=c.ModifiedDate,
                CategoryDescription=c.CategoryDescription,
                Name=c.Name,
                Url=c.Url
            }).ToList();
            CategoryPsychologistModel categoryPsychologistModel = new CategoryPsychologistModel();
            categoryPsychologistModel.Categories = categoriesModelList;
            categoryPsychologistModel.Psychologist = psychologistModelList;


            return View(categoryPsychologistModel);
        }
    }
}