using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Abstract
{
    public interface ICategoryDescriptionService
    {
        Task CreateAsync(CategoryDescription categoryDescription);
        Task<CategoryDescription> GetByIdAsync(int id);
        Task<List<CategoryDescription>> GetAllAsync();
        void Update(CategoryDescription categoryDescription);
        void Delete(CategoryDescription categoryDescription);

        Task<CategoryDescription> GetCategoryDescriptionByCategoryAsync(string categoryDescription);
    }
}
