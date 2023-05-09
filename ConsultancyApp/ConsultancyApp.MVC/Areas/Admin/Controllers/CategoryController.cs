using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Core;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.MVC.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConsultancyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryDescriptionService _categoryDescriptionService;
        private readonly IPsychologistService _psychologistService;

        public CategoryController(ICategoryService categoryService, IPsychologistService psychologistService, ICategoryDescriptionService categoryDescriptionService)
        {
            _categoryService = categoryService;
            _psychologistService = psychologistService;
            _categoryDescriptionService = categoryDescriptionService;
        }
        #region Listeleme
        public async Task<IActionResult> Index()
        {
            List<Category> categoryList = await _categoryService.GetAllCategoriesAsync();
            List<CategoryViewModel> categoryViewModel = new
            List<CategoryViewModel>();
            foreach (var c in categoryList)
            {
                categoryViewModel.Add(new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsApproved = c.IsApproved,
                    Url = c.Url,
                    Psychologists = c.PsychologitstCategry.Select(p => new PsychologistViewModel
                    {
                        Id = p.PsychologistId,
                        Name = p.Psychologist.Name,
                        IsApproved = p.Psychologist.IsApproved,
                        Url = p.Psychologist.Url,
                        Image = p.Psychologist.Image
                    }).ToList()

                });
            }
            return View(categoryViewModel);
        }
        #endregion
        #region Create
        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryAddViewModel categoryAddViewModel)
        {
            if (ModelState.IsValid)
            {
                CategoryDescription categoryDescription = new CategoryDescription
                {
                    Summary = categoryAddViewModel.Summary,
                    What = categoryAddViewModel.What,
                    How = categoryAddViewModel.How,
                    HowLong = categoryAddViewModel.HowLong,
                    ForWho = categoryAddViewModel.ForWho,
                    Purpose = categoryAddViewModel.Purpose,
                    PositiveEffect = categoryAddViewModel.PositiveEffect
                };
                Category category = new Category
                {
                    Name = categoryAddViewModel.Name,
                    Url = Jobs.GetUrl(categoryAddViewModel.Name),
                    IsApproved = categoryAddViewModel.IsApproved,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                await _categoryService.CreateCategory(category, categoryDescription);
                return RedirectToAction("Index");

            }
            return View(categoryAddViewModel);
        }
        #endregion
        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Category category = await _categoryService.GetCategoryFullDataAsync(id);
            CategoryUpdateViewModel categoryUpdateViewModel = new CategoryUpdateViewModel
            {
                Id=category.Id,
                Name=category.Name,
                ModifiedDate=DateTime.Now,
                IsApproved=category.IsApproved,
                Url=category.Url,

                Summary = category.CategoryDescription. Summary,
                What = category.CategoryDescription.What,
                How = category.CategoryDescription.How,
                HowLong = category.CategoryDescription.HowLong,
                ForWho = category.CategoryDescription.ForWho,
                Purpose = category.CategoryDescription.Purpose,
                PositiveEffect = category.CategoryDescription.PositiveEffect
            };            
            return View(categoryUpdateViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryUpdateViewModel categoryUpdateViewModel)
        {
            if(ModelState.IsValid)
            {
                CategoryDescription categoryDescription = await _categoryDescriptionService.GetCategoryDescriptionByCategoryAsync(categoryUpdateViewModel.Url);
                
                Category category = await _categoryService.GetCategoryFullDataAsync(categoryUpdateViewModel.Id);
                category.Name = categoryUpdateViewModel.Name;
                category.ModifiedDate = DateTime.Now;
                category.IsApproved = categoryUpdateViewModel.IsApproved;
                category.Url = categoryUpdateViewModel.Url;

                categoryDescription.Summary = categoryUpdateViewModel.Summary;
                categoryDescription.What = categoryUpdateViewModel.What;
                categoryDescription.How = categoryUpdateViewModel.How;
                categoryDescription.HowLong = categoryUpdateViewModel.HowLong;
                categoryDescription.ForWho = categoryUpdateViewModel.ForWho;
                categoryDescription.Purpose = categoryUpdateViewModel.Purpose;
                categoryDescription.PositiveEffect = categoryUpdateViewModel.PositiveEffect;
                await _categoryService.UpdateCategory(category, categoryDescription);
                return RedirectToAction("Index");
            }
            return View(categoryUpdateViewModel);
        }
        #endregion
        #region Delete
        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _categoryService.GetCategoryFullDataAsync(id);
            if(category!=null)
            {
                _categoryService.Delete(category);
            }
            return RedirectToAction("Index");
        }
        #endregion
        #region Onaylı mı
        public async Task<IActionResult> UpdateIsHome(int id, bool ApprovedStatus)
        {

            Category category = await _categoryService.GetByIdAsync(id);
            if (category != null)
            {
                category.IsApproved = !category.IsApproved;
                _categoryService.Update(category);
            }
            CategoryViewModel model = new CategoryViewModel
            {
                IsApproved = ApprovedStatus
            };
            return RedirectToAction("Index", model);

        }
        #endregion
        public async Task<IActionResult> GetCategoryByPsychologist(int id)
        {
            List<Category> categories = await _categoryService.GetCategoriesByPsyhologist(id);
            List<CategoryViewModel> categoryViews = new List<CategoryViewModel>();
            foreach(var c in categories)
            {
                categoryViews.Add(new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsApproved = c.IsApproved,
                    Url = c.Url,
                    Psychologists = c.PsychologitstCategry.Select(p => new PsychologistViewModel
                    {
                        Id = p.PsychologistId,
                        Name = p.Psychologist.Name,
                        IsApproved = p.Psychologist.IsApproved,
                        Url = p.Psychologist.Url,
                        Image = p.Psychologist.Image
                    }).ToList()

                });
            }
            return View("Index", categoryViews);
        }
    }
}
