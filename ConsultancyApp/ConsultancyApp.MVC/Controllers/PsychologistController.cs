using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConsultancyApp.MVC.Controllers
{
    public class PsychologistController : Controller
    {
        private IPsychologistService _psychologistService;
        private ICategoryService _categoryService;
        private IPsychologistDescriptionService _psychologistDescriptionService;
        private ICategoryDescriptionService _categoryDescriptionService;
        private ICustomerService _customerService;

        public PsychologistController(IPsychologistService psychologistService, ICategoryService categoryService, IPsychologistDescriptionService psychologistDescriptionService, ICategoryDescriptionService categoryDescriptionService, ICustomerService customerService)
        {
            _psychologistService = psychologistService;
            _categoryService = categoryService;
            _psychologistDescriptionService = psychologistDescriptionService;
            _categoryDescriptionService = categoryDescriptionService;
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            List<Psychologist> psychologists = await _psychologistService.GetAllPsychologistDataAsync();
            List<PsychologistModel> psychologistModelList = new List<PsychologistModel>();
            psychologistModelList = psychologists.Select(p => new PsychologistModel
            {
                Id = p.Id,
                Name = p.Name,
                CreatedDate = p.CreatedDate,
                ModifiedDate = p.ModifiedDate,
                Price = p.Price,
                Gender = p.Gender,
                Image = p.Image,
                categories = p.PsychologistCategory.Select(pc => pc.Category).ToList(),
            }).ToList();
            return View(psychologistModelList);
        }
        public async Task<IActionResult> PsychologistProfile(int id)
        {
            Psychologist p = await _psychologistService.GetPsychologistFullDataAsync(id);
            PsychologistModel psychologistModelList = new PsychologistModel();
            psychologistModelList.Name = p.Name;
            psychologistModelList.Price = p.Price;
            psychologistModelList.Gender = p.Gender;
            psychologistModelList.Image = p.Image;
            psychologistModelList.PsychologistDescription = p.PsychologistDescription;
            psychologistModelList.categories = p.PsychologistCategory.Select(pc => pc.Category).ToList();
            psychologistModelList.Url = p.Url;
            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = p.Gender == "Kadın" ? true : false
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = p.Gender == "Erkek" ? true : false
            });
            psychologistModelList.GenderSelectList = genderList;
            return View(psychologistModelList);
        }
    }
}
