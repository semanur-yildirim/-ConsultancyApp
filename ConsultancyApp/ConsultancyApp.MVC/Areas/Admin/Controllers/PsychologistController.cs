
using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.MVC.Areas.Admin.Models.ViewModels;
using ConsultancyApp.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConsultancyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PsychologistController : Controller
    {
        private readonly IPsychologistService _psychologistService;
        private readonly UserManager<User> _userManager;
        private readonly ICategoryService _categoryService;
        public PsychologistController(IPsychologistService psychologistService, UserManager<User> userManager, ICategoryService categoryService)
        {
            _psychologistService = psychologistService;
            _userManager = userManager;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<Psychologist> psychologistList = await _psychologistService.GetAllPsychologistDataAsync();
            List<PsychologistViewModel> psychologist = new List<PsychologistViewModel>();
            foreach (var p in psychologistList)
            {
                psychologist.Add(new PsychologistViewModel
                {
                    Id=p.Id,
                    Name=p.Name,
                    IsApproved=p.IsApproved,
                    Categories=p.PsychologistCategory.Select(c=> new CategoryViewModel{
                        Id=c.CategoryId,
                        Name=c.Category.Name,
                        IsApproved=c.Category.IsApproved,
                        Url=c.Category.Url,
                    }).ToList()
                });
            }
            return View(psychologist);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Psychologist psychologist = await _psychologistService.GetPsychologistFullDataAsync(id);
            User user = await _userManager.FindByIdAsync(psychologist.userId);
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.FirstName=user.FirstName;
            userViewModel.LastName=user.LastName;
            userViewModel.Email=user.Email;
            userViewModel.UserName=user.UserName;
            userViewModel.Type = user.Type;

            PsychologistUpdateViewModel psychologistUpdateViewModel = new PsychologistUpdateViewModel()
            {
                Id = psychologist.Id,
                Name = psychologist.Name,
                ModifiedDate = psychologist.ModifiedDate,
                IsApproved = psychologist.IsApproved,
                Url = psychologist.Url,
                Price = psychologist.Price,
                Gender = psychologist.Gender,
                Image = psychologist.Image,
                GraduationYear = psychologist.PsychologistDescription.GraduationYear,
                Experience = psychologist.PsychologistDescription.Experience,
                Education = psychologist.PsychologistDescription.Education,
                About = psychologist.PsychologistDescription.About,
                SelectedCategories = psychologist.PsychologistCategory.Select(c => c.CategoryId).ToArray(),
                Categories = await _categoryService.GetAllCategoriesAsync(true),
                User= userViewModel

            };
            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = psychologistUpdateViewModel.Gender == "Kadın" ? true : false
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = psychologistUpdateViewModel.Gender == "Erkek" ? true : false
            });
            genderList.Add(new SelectListItem
            {
                Text = "Diğer",
                Value = "Diger",
                Selected = psychologistUpdateViewModel.Gender == "Diğer" ? true : false
            });
            psychologistUpdateViewModel.GenderSelectList=genderList;
            return View(psychologistUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PsychologistUpdateViewModel psychologistUpdateViewModel)
        {
            if(ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(psychologistUpdateViewModel.User.Id);
                user.FirstName = psychologistUpdateViewModel.User.FirstName;
                user.LastName = psychologistUpdateViewModel.User.LastName;
                user.Email = psychologistUpdateViewModel.User.Email;
                user.EmailConfirmed = psychologistUpdateViewModel.User.EmailConfirmed;
                user.Type = psychologistUpdateViewModel.User.Type;
                user.UserName = psychologistUpdateViewModel.User.UserName;

                Psychologist psychologist = await _psychologistService.GetPsychologistFullDataAsync(psychologistUpdateViewModel.Id);
                psychologist.PsychologistDescription.About = psychologistUpdateViewModel.About;
                psychologist.PsychologistDescription.Education = psychologistUpdateViewModel.Education;
                psychologist.PsychologistDescription.Experience = psychologistUpdateViewModel.Experience;
                psychologist.PsychologistDescription.GraduationYear = psychologistUpdateViewModel.GraduationYear;
                psychologist.Url = psychologistUpdateViewModel.Url;
                psychologist.Gender = psychologistUpdateViewModel.Gender;
                psychologist.Price = psychologistUpdateViewModel.Price;
                psychologist.ModifiedDate = DateTime.Now;
                psychologist.Name = psychologistUpdateViewModel.Name;
                await _psychologistService.UpdatePsychologist(psychologist, psychologistUpdateViewModel.SelectedCategories);
                return RedirectToAction("Index");

            }
            return View(psychologistUpdateViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Psychologist psychologist = await _psychologistService.GetPsychologistFullDataAsync(id);
            PsychologistViewModel psychologistViewModel = new PsychologistViewModel
            {
                Id = psychologist.Id,
                Name = psychologist.Name,
                Url = psychologist.Url,
                IsApproved = psychologist.IsApproved,
                Categories = psychologist.PsychologistCategory.Select(c => new CategoryViewModel
                {
                    Id = c.CategoryId,
                    Name = c.Category.Name,
                }).ToList()

            };
            return View(psychologistViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(PsychologistViewModel psychologistViewModel)
        {
            Psychologist psychologist=await _psychologistService.GetByIdAsync(psychologistViewModel.Id);
            if(psychologist!=null)
            {
                _psychologistService.Delete(psychologist);
            }
            return RedirectToAction("Index");
        }
    }
}
