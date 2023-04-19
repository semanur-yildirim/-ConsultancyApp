using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ConsultancyApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IPsychologistService _psychologistService;
        private readonly ICustomerService _customerService;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IPsychologistService psychologistService, ICustomerService customerService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _psychologistService = psychologistService;
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }
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
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Manage(string username)
        {
            string name = username;
            if(String.IsNullOrEmpty(name))
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
            if (user.Type==EnumType.Psychologist)
            {
                Psychologist p = await _psychologistService.GetPsychologistFullDataByUserId(user.Id);
                PsychologistModel psychologistModelList = new PsychologistModel();
                psychologistModelList.IsApproved = p.IsApproved;
                psychologistModelList.Id = p.Id;
                psychologistModelList.Name = p.Name;
                psychologistModelList.CreatedDate = p.CreatedDate;
                psychologistModelList.ModifiedDate = p.ModifiedDate;
                psychologistModelList.Price = p.Price;
                psychologistModelList.Gender = p.Gender;
                psychologistModelList.Image = p.Image;
                psychologistModelList.PsychologistDescription = p.PsychologistDescription;
                psychologistModelList.categories = p.PsychologistCategory.Select(pc=>pc.Category).ToList();
                psychologistModelList.Url = p.Url;
                userManageViewModel.PsychologistModel = psychologistModelList;
            }
            return View(userManageViewModel);
        }
    }
}
