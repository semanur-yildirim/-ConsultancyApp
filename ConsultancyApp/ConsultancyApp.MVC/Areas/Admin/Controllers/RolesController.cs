using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.MVC.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsultancyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public RolesController(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<RoleViewModel> roleViewModels = await _roleManager.Roles.Select(r => new RoleViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToListAsync();

            return View(roleViewModels);
        }
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleAddViewModel roleAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new Role
                {
                    Name = roleAddViewModel.Name,
                    Description = roleAddViewModel.Description
                });
                return RedirectToAction("Index", "Roles");
            }
            return View(roleAddViewModel);
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            Role role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            var users = _userManager.Users.ToList();
            var members = new List<User>();
            var nonMembers = new List<User>();
            foreach (var user in users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            RoleUpdateViewModel roleUpdateViewModel = new RoleUpdateViewModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return View(roleUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleUpdateViewModel roleUpdateViewModel)
        {
            await InitialUsers(roleUpdateViewModel);
            return Redirect("/Admin/Roles/Edit/" + roleUpdateViewModel.Role.Id);

        }
        public async Task InitialUsers(RoleUpdateViewModel roleUpdateViewModel)
        {
            foreach (var userId in roleUpdateViewModel.IdsToAdd?? new string[] {})
            {
                User user = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.AddToRoleAsync(user, roleUpdateViewModel.Role.Name);
                if(!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            foreach (var userId in roleUpdateViewModel.IdsToRemove?? new string[] { })
            {
                User user = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.RemoveFromRoleAsync(user, roleUpdateViewModel.Role.Name);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
        }
        #endregion
    }
}
