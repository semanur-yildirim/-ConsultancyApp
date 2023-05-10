using AspNetCoreHero.ToastNotification.Abstractions;
using ConsultancyApp.Business.Abstract;
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

        public async Task<IActionResult> Index()
        {
            List<Request> requests = await _requestService.GetAllRequestFullDataAsync();

            return View(requests);
        }
    }
}
