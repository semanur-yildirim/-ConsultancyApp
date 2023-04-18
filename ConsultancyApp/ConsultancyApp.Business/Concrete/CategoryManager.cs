using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(Category category)
        {
            await _categoryRepository.CreateAsync(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();

        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<List<Category>> GetAllCategoriesAsync(bool ApprpvedStatus = false)
        {
            return await _categoryRepository.GetAllCategoriesAsync(ApprpvedStatus);
        }

        public async Task<List<Category>> GetCategoriesByPsyhologist(int id)
        {
            return await _categoryRepository.GetCategoriesByPsyhologist(id);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
