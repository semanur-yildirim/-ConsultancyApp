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
using System.Xml.Linq;

namespace ConsultancyApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IPsychologistService _psychologistService;
        private readonly ICustomerService _customerService;
        private readonly ICategoryService _categoryService;
        private readonly IRequestService _requestService;
        private readonly INotyfService _notyfService;
        private readonly ICartService _cartService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IPsychologistService psychologistService, ICustomerService customerService, ICategoryService categoryService, IRequestService requestService, INotyfService notyfService, ICartService cartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _psychologistService = psychologistService;
            _customerService = customerService;
            _categoryService = categoryService;
            _requestService = requestService;
            _notyfService = notyfService;
            _cartService = cartService;
        }
        #region Login
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(loginModel.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bilgileri hatalı!");
                    return View(loginModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, isPersistent: true, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return Redirect(loginModel.ReturnUrl ?? "/"); //nul ise anasayfaya dön
                }
                ModelState.AddModelError("", "Kullanıcı adı ya da parola hatalı!");
            }
            return View(loginModel);
        }
        #endregion
        #region Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #region Hesabım
        [HttpGet]
        public async Task<IActionResult> Manage(string username)
        {
            string name = username;
            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            User user = await _userManager.FindByNameAsync(name);

            if (user == null)
            {
                return NotFound();
            }
            UserManageModel userManageViewModel = new UserManageModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,
                Email = user.Email,
                //Type=user.Type
            };
            if (user.Type == EnumType.Psychologist)
            {

                Psychologist p = await _psychologistService.GetPsychologistFullDataByUserId(user.Id);
                PsychologistModel psychologistModelList = new PsychologistModel();
                psychologistModelList.Id = p.Id;
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
                userManageViewModel.PsychologistModel = psychologistModelList;
            }
            return View(userManageViewModel);
        }
        #endregion
        #region Customer Register
        [HttpGet]
        public async Task<IActionResult> CustomerRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CustomerRegister(CustomerRegisterModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    FirstName = customerViewModel.User.FirstName,
                    LastName = customerViewModel.User.LastName,
                    UserName = customerViewModel.User.UserName,
                    Email = customerViewModel.User.Email,
                    Type = customerViewModel.Type,
                    NormalizedName = (customerViewModel.User.FirstName + customerViewModel.User.LastName).ToUpper(),
                    DateOfBirth=customerViewModel.User.DateOfBirth
                };
                Customer customer = new Customer()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsApproved = customerViewModel.IsApproved,
                    Url = Jobs.GetUrl(customerViewModel.User.FirstName + customerViewModel.User.LastName),
                    Name = customerViewModel.User.FirstName + customerViewModel.User.LastName,
                    Address = customerViewModel.Address
                };
                var result = await _userManager.CreateAsync(user, customerViewModel.User.Password);
                customer.User = user;

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                    await _cartService.InitializeCart(user.Id);
                    
                }
                await _customerService.CreateAsync(customer);
                _notyfService.Success("Kaydınız başarıyla oluşturulmuştur.");
                return RedirectToAction("Index","Home");

            }
            return View(customerViewModel);
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> RegisterRequest()
        {
            RequestRegisterModel requestRegisterModel = new RequestRegisterModel()
            {
                Categories = await _categoryService.GetAllCategoriesAsync()
            };
            return View(requestRegisterModel);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterRequest(RequestRegisterModel requestRegisterModel)
        {
            User user = new User()
            {
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,

                FirstName = requestRegisterModel.User.FirstName,
                LastName = requestRegisterModel.User.LastName,
                UserName = requestRegisterModel.User.UserName,
                NormalizedName = (requestRegisterModel.User.LastName + requestRegisterModel.User.UserName).ToUpper(),
                Email = requestRegisterModel.User.Email,
                NormalizedEmail = (requestRegisterModel.User.Email).ToUpper(),
                PasswordHash=requestRegisterModel.User.Password,
                Type = EnumType.Request,
                DateOfBirth=requestRegisterModel.User.DateOfBirth
            };
            Image image = new Image();
            image.CreatedDate = DateTime.Now;
            image.ModifiedDate = DateTime.Now;
            image.IsApproved = true;
            image.Url = Jobs.UploadImage(requestRegisterModel.Image);
            Request request = new Request()
            {
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsApproved = requestRegisterModel.IsApproved,
                About = requestRegisterModel.About,
                Education = requestRegisterModel.Education,
                Experience = requestRegisterModel.Experience,
                Gender = requestRegisterModel.Gender,
                GraduationYear = requestRegisterModel.GraduationYear,
                Price=requestRegisterModel.Price,
                Url = Jobs.GetUrl(requestRegisterModel.User.FirstName + requestRegisterModel.User.LastName),
                Image=image
            };
            var result = await _userManager.CreateAsync(user, requestRegisterModel.User.Password);
            request.User = user;

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Request");
            }

            await _requestService.CreateRequest(request, requestRegisterModel.SelectedCategories, image);
            _notyfService.Success("Talebiniz oluşturuldu.");
            return RedirectToAction("Index","Home");
        }
    }
}
