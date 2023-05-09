
using AspNetCoreHero.ToastNotification.Abstractions;
using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Core;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.MVC.Areas.Admin.Models.ViewModels;
using ConsultancyApp.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.DependencyResolver;

namespace ConsultancyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PsychologistController : Controller
    {
        private readonly IPsychologistService _psychologistService;
        private readonly IPsychologistDescriptionService _psychologistDescriptionService;

        private ICustomerService _customerService;
        private readonly UserManager<User> _userManager;
        private readonly ICategoryService _categoryService;
        private readonly RoleManager<Role> _roleManager;
        private readonly IImageService _imageService;
        private readonly INotyfService _notyfService;

        public PsychologistController(IPsychologistService psychologistService, UserManager<User> userManager, ICategoryService categoryService, RoleManager<Role> roleManager, ICustomerService customerService, IImageService imageService, IPsychologistDescriptionService psychologistDescriptionService, INotyfService notyfService)
        {
            _psychologistService = psychologistService;
            _userManager = userManager;
            _categoryService = categoryService;
            _roleManager = roleManager;
            _customerService = customerService;
            _imageService = imageService;
            _psychologistDescriptionService = psychologistDescriptionService;
            _notyfService = notyfService;
        }
        #region List
        public async Task<IActionResult> Index()
        {
            List<Psychologist> psychologistList = await _psychologistService.GetAllPsychologistDataAsync();

            List<PsychologistViewModel> psychologist = new List<PsychologistViewModel>();
            foreach (var p in psychologistList)
            {
                psychologist.Add(new PsychologistViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    IsApproved = p.IsApproved,
                    Categories = p.PsychologistCategory.Select(c => new Category
                    {
                        Id = c.CategoryId,
                        Name = c.Category.Name,
                        IsApproved = c.Category.IsApproved,
                        Url = c.Category.Url,
                    }).ToList(),
                    Customers = p.PsychologistCustomer.Select(c => new CustomerViewModel
                    {
                        Id = c.CustomerId,
                        Name = c.Customer.Name,
                        Address = c.Customer.Address,
                        IsApproved = c.Customer.IsApproved,
                        Url = c.Customer.Url

                    }).ToList(),
                    Image = p.Image
                });
            }
            return View(psychologist);
        }
        #endregion
        #region Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            PsychologistAddViewModel psychologistAddViewModel = new PsychologistAddViewModel()
            {
                Categories = await _categoryService.GetAllCategoriesAsync()
            };
            return View(psychologistAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PsychologistAddViewModel psychologistAddViewModel)
        {
            if (ModelState.IsValid)
            {
                PsychologistDescription psychologistDescription = new PsychologistDescription()
                {
                    About = psychologistAddViewModel.About,
                    Education = psychologistAddViewModel.Education,
                    Experience = psychologistAddViewModel.Experience,
                    GraduationYear = psychologistAddViewModel.GraduationYear,
                };
                User user = new User()
                {
                    FirstName = psychologistAddViewModel.User.FirstName,
                    LastName = psychologistAddViewModel.User.LastName,
                    UserName = psychologistAddViewModel.User.UserName,
                    Email = psychologistAddViewModel.User.Email,
                    Type = psychologistAddViewModel.Type
                };
                Image image = new Image();
                image.CreatedDate = DateTime.Now;
                image.ModifiedDate = DateTime.Now;
                image.IsApproved = true;
                image.Url = Jobs.UploadImage(psychologistAddViewModel.Image);

                Psychologist psychologist = new Psychologist()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,

                    IsApproved = psychologistAddViewModel.IsApproved,
                    Url = Jobs.GetUrl(psychologistAddViewModel.User.FirstName + psychologistAddViewModel.User.LastName),
                    Price = psychologistAddViewModel.Price,
                    Gender = psychologistAddViewModel.Gender,
                    Name = psychologistAddViewModel.User.FirstName + psychologistAddViewModel.User.LastName,
                };

                var result = await _userManager.CreateAsync(user, psychologistAddViewModel.User.Password);
                psychologist.User = user;

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Psychologist");
                }

                await _psychologistService.CreatePsychologist(psychologist, psychologistAddViewModel.SelectedCategories, image, psychologistDescription);
                return RedirectToAction("Index");

            }
            return View(psychologistAddViewModel);
        }
        #endregion
        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Psychologist psychologist = await _psychologistService.GetPsychologistFullDataAsync(id);

            User user = await _userManager.FindByIdAsync(psychologist.UserId);

            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Id = psychologist.UserId;
            userViewModel.FirstName = user.FirstName;
            userViewModel.LastName = user.LastName;
            userViewModel.Email = user.Email;
            userViewModel.UserName = user.UserName;
            userViewModel.Type = user.Type;
            userViewModel.Password = user.PasswordHash;

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
                User = userViewModel

            };
            #region Gender
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
            psychologistUpdateViewModel.GenderSelectList = genderList;

            #endregion

            return View(psychologistUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PsychologistUpdateViewModel psychologistUpdateViewModel)
        {
            var psychologistDescription = await _psychologistDescriptionService.GetPsychologistDescriptionByPsychologistAsync(psychologistUpdateViewModel.Id);

            var psy = await _psychologistService.GetPsychologistFullDataByUserId(psychologistUpdateViewModel.User.Id);

            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(psychologistUpdateViewModel.User.Id);
                user.Id = psychologistUpdateViewModel.User.Id;
                user.FirstName = psychologistUpdateViewModel.User.FirstName;
                user.LastName = psychologistUpdateViewModel.User.FirstName;
                user.Email = psychologistUpdateViewModel.User.Email;
                user.EmailConfirmed = psychologistUpdateViewModel.User.EmailConfirmed;
                user.Type = psychologistUpdateViewModel.User.Type;
                user.UserName = psychologistUpdateViewModel.User.UserName;
                user.NormalizedName = (psychologistUpdateViewModel.User.FirstName + psychologistUpdateViewModel.User.FirstName).ToUpper();
                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded) { return NotFound(); }
                var userRoles = await _userManager.GetRolesAsync(user);
                if (psychologistUpdateViewModel.User.Type == EnumType.Admin)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    await _userManager.RemoveFromRoleAsync(user, "Customer");
                    await _userManager.RemoveFromRoleAsync(user, "Psychologist");
                    _psychologistService.Delete(psy);
                }
                else if (psychologistUpdateViewModel.User.Type == EnumType.Customer)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                    await _userManager.RemoveFromRoleAsync(user, "Psychologist");
                    await _userManager.RemoveFromRoleAsync(user, "Admin");
                    _psychologistService.Delete(psy);
                    Customer customer = new Customer();
                    customer.Name = psychologistUpdateViewModel.Name;
                    customer.CreatedDate = DateTime.Now;
                    customer.Url = Jobs.GetUrl(customer.Name);
                    customer.userId = psychologistUpdateViewModel.User.Id;
                   await _customerService.CreateAsync(customer);
                }
                else if (psychologistUpdateViewModel.User.Type == EnumType.Psychologist)
                {
                    await _userManager.AddToRoleAsync(user, "Psychologist");
                    await _userManager.RemoveFromRoleAsync(user, "Customer");
                    await _userManager.RemoveFromRoleAsync(user, "Admin");

                    psychologistDescription.About = psychologistUpdateViewModel.About;
                    psychologistDescription.Education = psychologistUpdateViewModel.Education;
                    psychologistDescription.Experience = psychologistUpdateViewModel.Experience;
                    psychologistDescription.GraduationYear = psychologistUpdateViewModel.GraduationYear;

                    Psychologist psychologist = await _psychologistService.GetPsychologistFullDataAsync(psychologistUpdateViewModel.Id);
                    psychologist.UserId = psychologistUpdateViewModel.User.Id;
                    psychologist.Url = psychologistUpdateViewModel.Url;
                    psychologist.Gender = psychologistUpdateViewModel.Gender;
                    psychologist.Price = psychologistUpdateViewModel.Price;
                    psychologist.ModifiedDate = DateTime.Now;
                    psychologist.Name = psychologistUpdateViewModel.Name;
                    if (psychologistUpdateViewModel.File != null)
                    {
                        psychologist.Image = new Image
                        {
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            IsApproved = true,
                            Url = Jobs.UploadImage(psychologistUpdateViewModel.File)
                        };
                        await _imageService.CreateAsync(psychologist.Image);
                    }

                    await _psychologistService.UpdatePsychologist(psychologist, psychologistUpdateViewModel.SelectedCategories, psychologistDescription);
                }
                return RedirectToAction("Index");
            }
            return View(psychologistUpdateViewModel);
        }
        #endregion
        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            Psychologist psychologist = await _psychologistService.GetPsychologistFullDataAsync(id);
            User user = await _userManager.FindByIdAsync(psychologist.UserId);

            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
        #endregion
        #region Onaylı mı
        public async Task<IActionResult> UpdateIsHome(int id,bool ApprovedStatus)
        {

                Psychologist psychologist = await _psychologistService.GetByIdAsync(id);
                if (psychologist != null)
                {
                    psychologist.IsApproved = !psychologist.IsApproved;
                    _psychologistService.Update(psychologist);
                }
                PsychologistViewModel model = new PsychologistViewModel
                {
                    IsApproved = ApprovedStatus
                };
            return RedirectToAction("Index", model);

        }
        #endregion

        public async Task<IActionResult> GetPsychologistByCustomer(int id)
        {
            List<Psychologist> psychologistList = await _psychologistService.GetPsychologistsByCategoriesAsync(id);
            List<PsychologistViewModel> psychologist = new List<PsychologistViewModel>();
            foreach (var p in psychologistList)
            {
                psychologist.Add(new PsychologistViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    IsApproved = p.IsApproved,
                    Categories = p.PsychologistCategory.Select(c => new Category
                    {
                        Id = c.CategoryId,
                        Name = c.Category.Name,
                        IsApproved = c.Category.IsApproved,
                        Url = c.Category.Url,
                    }).ToList(),
                    Customers = p.PsychologistCustomer.Select(c => new CustomerViewModel
                    {
                        Id = c.CustomerId,
                        Name = c.Customer.Name,
                        Address = c.Customer.Address,
                        IsApproved = c.Customer.IsApproved,
                        Url = c.Customer.Url

                    }).ToList(),
                    Image = p.Image
                });
            }
            return View("Index", psychologist);
        }
    }
}
