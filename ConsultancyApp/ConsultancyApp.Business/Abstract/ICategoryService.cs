using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Abstract
{
    public interface ICategoryService
    {
        Task CreateAsync(Category category);
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync();
        void Update(Category category);
        void Delete(Category category);
        Task<Category> GetCategoryDetailsByUrlAsync(string url);

        Task<List<Category>> GetAllCategoriesAsync(bool ApprpvedStatus=false);
        Task<List<Category>> GetCategoriesByPsyhologist(int id);
        Task CreateCategory(Category category, CategoryDescription categoryDescription);
        Task UpdateCategory(Category category, CategoryDescription categoryDescription);

        Task<Category> GetCategoryFullDataAsync(int id);

    }
}
