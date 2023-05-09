using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Core;
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
        #region Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerAddViewModel customerAddViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    FirstName = customerAddViewModel.User.FirstName,
                    LastName = customerAddViewModel.User.LastName,
                    UserName = customerAddViewModel.User.UserName,
                    Email = customerAddViewModel.User.Email,
                    Type = customerAddViewModel.Type,
                    NormalizedName = (customerAddViewModel.User.FirstName + customerAddViewModel.User.LastName).ToUpper()
                };
                Customer customer = new Customer()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsApproved = customerAddViewModel.IsApproved,
                    Url = Jobs.GetUrl(customerAddViewModel.User.FirstName + customerAddViewModel.User.LastName),
                    Name = customerAddViewModel.User.FirstName + customerAddViewModel.User.LastName,
                    Address = customerAddViewModel.Address
                };
                var result = await _userManager.CreateAsync(user, customerAddViewModel.User.Password);
                customer.User = user;

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                }
                await _customerService.CreateAsync(customer);
                return RedirectToAction("Index");

            }
            return View(customerAddViewModel);
        }
        #endregion
        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            Customer customer = await _customerService.GetCustomerFullDataAsync(id);
            User user = await _userManager.FindByIdAsync(customer.userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
        #endregion
        #region Edit
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }
        #endregion

    }
}
