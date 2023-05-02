using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<List<Category>> GetAllCategoriesAsync(bool ApprpvedStatus=false);
        Task<List<Category>> GetCategoriesByPsyhologist(int id);
        Task<Category> GetCategoryDetailsByUrlAsync(string url);
        Task CreateCategory(Category category, CategoryDescription categoryDescription);
        Task UpdateCategory(Category category, CategoryDescription categoryDescription);
        Task<Category> GetCategoryFullDataAsync(int id);

     
    }   
}
