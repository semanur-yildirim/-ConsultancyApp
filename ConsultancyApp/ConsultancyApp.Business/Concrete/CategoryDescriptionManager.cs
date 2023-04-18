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
    public class CategoryDescriptionManager:ICategoryDescriptionService
    {
        private ICategoryDescriptionRepository _categoryDescriptionRepository;

        public CategoryDescriptionManager(ICategoryDescriptionRepository categoryDescriptionRepository)
        {
            _categoryDescriptionRepository = categoryDescriptionRepository;
        }

        public async Task CreateAsync(CategoryDescription categoryDescription)
        {
            await _categoryDescriptionRepository.CreateAsync(categoryDescription);
        }

        public void Delete(CategoryDescription categoryDescription)
        {
            _categoryDescriptionRepository.Delete(categoryDescription);
        }

        public  async Task<List<CategoryDescription>> GetAllAsync()
        {
            return await _categoryDescriptionRepository.GetAllAsync();
        }

        public async Task<CategoryDescription> GetByIdAsync(int id)
        {
            return await _categoryDescriptionRepository.GetByIdAsync(id);
        }

        public async Task<CategoryDescription> GetCategoryDescriptionByCategoryAsync(string categoryurl)
        {
            return await _categoryDescriptionRepository.GetCategoryDescriptionByCategoryAsync(categoryurl);
        }

        public void Update(CategoryDescription categoryDescription)
        {
            _categoryDescriptionRepository.Update(categoryDescription);
        }
    }
}
