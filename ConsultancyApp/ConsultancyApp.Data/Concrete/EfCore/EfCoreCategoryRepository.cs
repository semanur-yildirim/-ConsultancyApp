using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Data.Concrete.EfCore.Context;
using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsultancyApp.Data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(ConsultancyAppContext _appContext) : base(_appContext)
        {
        }
        ConsultancyAppContext AppContext
        {
            get { return _dbContext as ConsultancyAppContext; }
        }

        public async Task CreateCategory(Category category, CategoryDescription categoryDescription)
        {
            await AppContext.Categories.AddAsync(category);
            await AppContext.SaveChangesAsync();

            categoryDescription.CategoryId = category.Id;

            await AppContext.CategoryDescription.AddAsync(categoryDescription);
            await AppContext.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllCategoriesAsync(bool ApprovedStatus=false)
        {
            var categories = AppContext.Categories.Include(pc=>pc.PsychologitstCategry).ThenInclude(p=>p.Psychologist)
                 .Include(cd => cd.CategoryDescription).AsQueryable();
            if (ApprovedStatus)
            {
                categories=categories.Where(p => p.IsApproved == ApprovedStatus);
            }
            return await categories.ToListAsync();
         
        }
        public async Task<List<Category>> GetCategoriesByPsyhologist(int id)
        {
            List<Category> psychologists = await
                AppContext.Categories
            .Include(p => p.PsychologitstCategry)
            .ThenInclude(pc => pc.Psychologist).Where(p => p.PsychologitstCategry.Any(x => x.PsychologistId == id)).ToListAsync();
            return psychologists;
        }

        public async Task<Category> GetCategoryDetailsByUrlAsync(string url)
        {
            var resultCategory =  AppContext.Categories
                .Where(c=>c.Url==url)
                .Include(c => c.CategoryDescription).FirstOrDefault();
            return  resultCategory;
        }

        public async Task<Category> GetCategoryFullDataAsync(int id)
        {
            return await AppContext.Categories.Where(c => c.Id == id).Include(c => c.CategoryDescription).FirstOrDefaultAsync();
        }

        public async Task UpdateCategory(Category category, CategoryDescription categoryDescription)
        {
          
           var updateCategory=await AppContext.Categories.Include(c=>c.CategoryDescription).FirstOrDefaultAsync(p=>p.Id==category.Id);

            updateCategory.Name = category.Name;
            updateCategory.IsApproved = category.IsApproved;
            updateCategory.Url = category.Url;
            updateCategory.ModifiedDate = category.ModifiedDate;
           // updateCategory.CategoryDescription = categoryDescription;

            updateCategory.CategoryDescription.CategoryId = categoryDescription.CategoryId;
            updateCategory.CategoryDescription.Summary = categoryDescription.Summary;
            updateCategory.CategoryDescription.What = categoryDescription.What;
            updateCategory.CategoryDescription.How = categoryDescription.How;
            updateCategory.CategoryDescription.ForWho = categoryDescription.ForWho;
            updateCategory.CategoryDescription.HowLong = categoryDescription.HowLong;
            AppContext.Update(updateCategory);
            await AppContext.SaveChangesAsync();
        }
    }
}
