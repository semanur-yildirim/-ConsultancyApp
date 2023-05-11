using AspNetCoreHero.ToastNotification.Abstractions;
using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Core;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.MVC.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConsultancyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class RequestController : Controller
    {
        private readonly IPsychologistService _psychologistService;
        private readonly IPsychologistDescriptionService _psychologistDescriptionService;

        private ICustomerService _customerService;
        private readonly UserManager<User> _userManager;
        private readonly ICategoryService _categoryService;
        private readonly RoleManager<Role> _roleManager;
        private readonly IImageService _imageService;
        private readonly INotyfService _notyfService;
        private readonly IRequestService _requestService;
        public RequestController(IPsychologistService psychologistService, IPsychologistDescriptionService psychologistDescriptionService, ICustomerService customerService, UserManager<User> userManager, ICategoryService categoryService, RoleManager<Role> roleManager, IImageService imageService, INotyfService notyfService, IRequestService requestService)
        {
            _psychologistService = psychologistService;
            _psychologistDescriptionService = psychologistDescriptionService;
            _customerService = customerService;
            _userManager = userManager;
            _categoryService = categoryService;
            _roleManager = roleManager;
            _imageService = imageService;
            _notyfService = notyfService;
            _requestService = requestService;
        }
        #region List
        public async Task<IActionResult> Index()
        {
            List<Request> requests = await _requestService.GetAllRequestFullDataAsync();
            List<RequestViewModel> request = new List<RequestViewModel>();

            foreach (var p in requests)
            {
                request.Add(new RequestViewModel
                {
                    Id = p.Id,
                    IsApproved = p.IsApproved,
                    Name = p.User.FirstName + " " + p.User.LastName,
                    Categories = p.RequestCategories.Select(c => new Category
                    {
                        Id = c.CategoryId,
                        Name = c.Category.Name,
                        IsApproved = c.Category.IsApproved,
                        Url = c.Category.Url,
                    }).ToList(),
                    Image = p.Image
                });
            }
            return View(request);
        }
        #endregion
        #region Manage
        [HttpGet]
        public async Task<IActionResult> Manage(int id)
        {
            Request request = await _requestService.GetRequestFullDataAsync(id);
            User user = await _userManager.FindByIdAsync(request.UserId);

            PsychologistUpdateViewModel psychologistAddViewModel = new PsychologistUpdateViewModel()
            {
                Price = request.Price,
                Name = request.User.FirstName + " " + request.User.LastName,
                Gender = request.Gender,
                Image = request.Image,
                GraduationYear = request.GraduationYear,
                Url = request.Url,
                Experience = request.Experience,
                Education = request.Education,
                About = request.About,
                Categories = request.RequestCategories.Select(c => new Category
                {
                    Id = c.CategoryId,
                    Name = c.Category.Name,
                }).ToList(),
                User =new UserViewModel()
                {
                    Id= user.Id,
                    FirstName= user.FirstName,
                    LastName= user.LastName,
                    UserName= user.UserName,
                    Email= user.Email,
                    EmailConfirmed= user.EmailConfirmed,
                    Password=user.PasswordHash
                },
                 SelectedCategories = request.RequestCategories.Select(c => c.CategoryId).ToArray(),

            };
            return View(psychologistAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Manage(PsychologistUpdateViewModel psychologistUpdateViewModel)
        {
           if(ModelState.IsValid)
            {
                User deleteUser = await _userManager.FindByIdAsync(psychologistUpdateViewModel.User.Id);
                if (deleteUser != null)
                {
                    await _userManager.DeleteAsync(deleteUser);
                }

                PsychologistDescription psychologistDescription = new PsychologistDescription()
                {
                    About = psychologistUpdateViewModel.About,
                    Education = psychologistUpdateViewModel.Education,
                    Experience = psychologistUpdateViewModel.Experience,
                    GraduationYear = psychologistUpdateViewModel.GraduationYear,
                };
                User user = new User()
                {
                    FirstName = psychologistUpdateViewModel.User.FirstName,
                    LastName = psychologistUpdateViewModel.User.LastName,
                    UserName = psychologistUpdateViewModel.User.UserName,
                    Email = psychologistUpdateViewModel.User.Email,
                    Type = EnumType.Psychologist,
                };
                Image image = new Image();
                image.CreatedDate = DateTime.Now;
                image.ModifiedDate = DateTime.Now;
                image.IsApproved = true;
                image.Url = psychologistUpdateViewModel.Image.Url;

                Psychologist psychologist = new Psychologist()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,

                    IsApproved = true,
                    Url = Jobs.GetUrl(psychologistUpdateViewModel.User.FirstName + psychologistUpdateViewModel.User.LastName),
                    Price = psychologistUpdateViewModel.Price,
                    Gender = psychologistUpdateViewModel.Gender,
                    Name = psychologistUpdateViewModel.User.FirstName + psychologistUpdateViewModel.User.LastName,
                };
                var result = await _userManager.CreateAsync(user, psychologistUpdateViewModel.User.Password);
                psychologist.User = user;

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Psychologist");
                }

                await _psychologistService.CreatePsychologist(psychologist, psychologistUpdateViewModel.SelectedCategories, image, psychologistDescription);
                return RedirectToAction("Index");



            }
            return View(psychologistUpdateViewModel);
        }
        #endregion
        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            Request psychologist = await _requestService.GetRequestFullDataAsync(id);
            User user = await _userManager.FindByIdAsync(psychologist.UserId);

            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
        #endregion


    }
}
