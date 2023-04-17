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
            return View(psychologistModelList);
        }
    }
}