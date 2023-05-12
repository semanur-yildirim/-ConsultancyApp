using AspNetCoreHero.ToastNotification.Abstractions;
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
        private readonly ICartService _cartService;
        private readonly INotyfService _notyfService;

        public CustomerController(ICustomerService customerService, RoleManager<Role> roleManager, UserManager<User> userManager, IPsychologistService psychologistService, ICartService cartService, INotyfService notyfService)
        {
            _customerService = customerService;
            _roleManager = roleManager;
            _userManager = userManager;
            _psychologistService = psychologistService;
            _cartService = cartService;
            _notyfService = notyfService;
        }
        #region List
        public async Task<IActionResult> Index()
        {
            List<Customer> customerList = await _customerService.GetAllCustomerFullDataAsycn();
            List<CustomerViewModel> customerViewModel = new List<CustomerViewModel>();
            foreach (var p in customerList)
            {
                customerViewModel.Add(new CustomerViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Address = p.Address,
                    IsApproved = p.IsApproved,
                    Url = p.Url,
                    Psychologists = p.PsychologistCustomer.Select(c => new PsychologistViewModel
                    {
                        Id = c.PsychologistId,
                        Name = c.Psychologist.Name,
                        Url = c.Psychologist.Url,
                        Image = c.Psychologist.Image,
                        IsApproved = c.Psychologist.IsApproved
                    }).ToList()
                });
            }
            return View(customerViewModel);
        }
        #endregion
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
                    NormalizedName = (customerAddViewModel.User.FirstName + customerAddViewModel.User.LastName).ToUpper(),
                    DateOfBirth=customerAddViewModel.User.DateOfBirth,
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
                    await _cartService.InitializeCart(user.Id);
                }
                await _customerService.CreateAsync(customer);
                _notyfService.Success("Kayıt başarıyla oluşturulmuştur.");

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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerService.GetCustomerFullDataAsync(id);
            var user = await _userManager.FindByIdAsync(customer.userId);
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Id = customer.userId;
            userViewModel.FirstName = user.FirstName;
            userViewModel.LastName = user.LastName;
            userViewModel.Email = user.Email;
            userViewModel.UserName = user.UserName;
            userViewModel.Type = user.Type;
            userViewModel.Password = user.PasswordHash;
            userViewModel.DateOfBirth = user.DateOfBirth;

            CustomerUpdateViewModel customerUpdateViewModel = new CustomerUpdateViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                ModifiedDate = customer.ModifiedDate,
                Url = customer.Url,
                Address = customer.Address,
                IsApproved = customer.IsApproved,
                User = userViewModel
            };
            return View(customerUpdateViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerUpdateViewModel customerUpdateViewModel)
        {
            var customer = await _customerService.GetCustomerFullDataAsync(customerUpdateViewModel.Id);
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(customerUpdateViewModel.User.Id);
                user.Id = customerUpdateViewModel.User.Id;
                user.FirstName = customerUpdateViewModel.User.FirstName;
                user.LastName = customerUpdateViewModel.User.LastName;
                user.Email = customerUpdateViewModel.User.Email;
                user.EmailConfirmed = customerUpdateViewModel.User.EmailConfirmed;
                user.Type = customerUpdateViewModel.User.Type;
                user.UserName = customerUpdateViewModel.User.UserName;
                user.DateOfBirth = customerUpdateViewModel.User.DateOfBirth;
                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded) { return NotFound(); }
                var userRoles = await _userManager.GetRolesAsync(user);
                if (customerUpdateViewModel.User.Type == EnumType.Admin)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                    await _userManager.RemoveFromRoleAsync(user, "Customer");
                    await _userManager.RemoveFromRoleAsync(user, "Psychologist");
                    _customerService.Delete(customer);
                }
                else if (customerUpdateViewModel.User.Type == EnumType.Customer)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                    await _userManager.RemoveFromRoleAsync(user, "Psychologist");
                    await _userManager.RemoveFromRoleAsync(user, "Admin");
                    _customerService.Delete(customer);
                    Customer newCustomer = new Customer();
                    newCustomer.Name = customerUpdateViewModel.User.FirstName+customerUpdateViewModel.User.LastName;
                    newCustomer.CreatedDate = DateTime.Now;
                    newCustomer.Url = Jobs.GetUrl(customer.Name);
                    newCustomer.userId = customerUpdateViewModel.User.Id;
                    newCustomer.IsApproved = customerUpdateViewModel.IsApproved;
                    await _customerService.CreateAsync(customer);
                }
                return RedirectToAction("Index");
            }
            return View(customerUpdateViewModel);

        }
        #endregion
        #region Onaylı mı
        public async Task<IActionResult> UpdateIsHome(int id, bool ApprovedStatus)
        {

            Customer customer = await _customerService.GetByIdAsync(id);
            if (customer != null)
            {
                customer.IsApproved = !customer.IsApproved;
                _customerService.Update(customer);
            }
            CustomerViewModel model = new CustomerViewModel
            {
                IsApproved = ApprovedStatus
            };
            return RedirectToAction("Index", model);

        }
        #endregion

    }
}
