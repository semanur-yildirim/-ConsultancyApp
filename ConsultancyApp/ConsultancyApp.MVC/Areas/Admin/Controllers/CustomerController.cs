using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.MVC.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConsultancyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IPsychologistService _psychologistService;

        public CustomerController(ICustomerService customerService, RoleManager<Role> roleManager, UserManager<User> userManager, IPsychologistService psychologistService)
        {
            _customerService = customerService;
            _roleManager = roleManager;
            _userManager = userManager;
            _psychologistService = psychologistService;
        }

        public async Task<IActionResult> Index()
        {
            List<Customer> customerList = await _customerService.GetAllCustomerFullDataAsycn();
            List<CustomerViewModel> customerViewModel = new List<CustomerViewModel>();
            foreach (var p in customerList)
            {
                customerViewModel.Add(new CustomerViewModel
                {
                    Id=p.Id,
                    Name = p.Name,
                    Address=p.Address,
                    IsApproved=p.IsApproved,
                    Url=p.Url,
                    Psychologists=p.PsychologistCustomer.Select(c=>new PsychologistViewModel
                    {
                        Id=c.PsychologistId,
                        Name=c.Psychologist.Name,
                        Url=c.Psychologist.Url,
                        Image=c.Psychologist.Image,
                        IsApproved=c.Psychologist.IsApproved
                    }).ToList() 
                });
            }
            return View(customerViewModel);
        }

    }
}
