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
        public async Task<IActionResult> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ConfirmEmail(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            user.EmailConfirmed = !user.EmailConfirmed;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
    }
}