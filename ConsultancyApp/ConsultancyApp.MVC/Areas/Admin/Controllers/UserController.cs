using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.MVC.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConsultancyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IPsychologistService _psychologistService;
        private readonly ICustomerService _customerService;
        private readonly ICategoryService _categoryService;

        public UserController(UserManager<User> userManager, RoleManager<Role> roleManager, IPsychologistService ipsychologistService, ICustomerService customerService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _psychologistService = ipsychologistService;
            _customerService = customerService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            List<UserViewModel> users = await _userManager.Users.Select(u => new UserViewModel
            {
                Id=u.Id,
                FirstName=u.FirstName,
                LastName=u.LastName,
                Email=u.Email,EmailConfirmed=u.EmailConfirmed,
                Type=u.Type,                
            }).ToListAsync();
            return View(users);
        }
        //[HttpGet]
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (String.IsNullOrEmpty(id)) { return NotFound(); }
        //    User user=await _userManager.FindByIdAsync(id);
        //    if (user == null) { return NotFound(); }
        //    UserViewModel userViewModel = new UserViewModel
        //    {
        //        Id = user.Id,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Email = user.Email,
        //        EmailConfirmed = user.EmailConfirmed,
        //        Type = user.Type,
        //        UserName=user.UserName
        //    };
        //    #region Psikolog Bilgileri Dolduruluyor.
        //    if (user.Type == EnumType.Psychologist)
        //    {
        //        Psychologist psychologist = await _psychologistService.GetPsychologistFullDataByUserId(id);
        //        PsychologistUpdateViewModel psychologistUpdateViewModel = new PsychologistUpdateViewModel();

        //        psychologistUpdateViewModel.Id = psychologist.Id;
        //        psychologistUpdateViewModel.Name = psychologist.Name;
        //        psychologistUpdateViewModel.ModifiedDate = psychologist.ModifiedDate;
        //        psychologistUpdateViewModel.IsApproved = psychologist.IsApproved;
        //        psychologistUpdateViewModel.Url = psychologist.Url;
        //        psychologistUpdateViewModel.Price = psychologist.Price;
        //        psychologistUpdateViewModel.Gender = psychologist.Gender;
        //        psychologistUpdateViewModel.Image = psychologist.Image;
        //        psychologistUpdateViewModel.GraduationYear = psychologist.PsychologistDescription.GraduationYear;
        //        psychologistUpdateViewModel.Experience = psychologist.PsychologistDescription.Experience;
        //        psychologistUpdateViewModel.Education = psychologist.PsychologistDescription.Education;
        //        psychologistUpdateViewModel.About = psychologist.PsychologistDescription.About;
        //        psychologistUpdateViewModel.SelectedCategories = psychologist.PsychologistCategory.Select(c => c.CategoryId).ToArray();
        //        psychologistUpdateViewModel.Categories = await _categoryService.GetAllCategoriesAsync(true);
        //        #region Cinsiyet Bilgileri
        //        List<SelectListItem> genderList = new List<SelectListItem>();
        //        genderList.Add(new SelectListItem
        //        {
        //            Text = "Kadın",
        //            Value = "Kadın",
        //            Selected = psychologistUpdateViewModel.Gender == "Kadın" ? true : false
        //        });
        //        genderList.Add(new SelectListItem
        //        {
        //            Text = "Erkek",
        //            Value = "Erkek",
        //            Selected = psychologistUpdateViewModel.Gender == "Erkek" ? true : false
        //        });
        //        genderList.Add(new SelectListItem
        //        {
        //            Text = "Diğer",
        //            Value = "Diger",
        //            Selected = psychologistUpdateViewModel.Gender == "Diğer" ? true : false
        //        });
        //        psychologistUpdateViewModel.GenderSelectList = genderList;
        //        #endregion
        //        psychologistUpdateViewModel.User = userViewModel;

        //        userViewModel.Psychlogist = psychologistUpdateViewModel;

        //    }
        //    #endregion
        //    #region Danışan Bilgileri Dolduruluyor.
        //    if(user.Type==EnumType.Customer)
        //    {

        //    }
        //    #endregion
        //    return View(userViewModel);
        //}

        public async Task<IActionResult> Edit(int id)
        {


            return View();
        }
        public async Task<IActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
    }
}
