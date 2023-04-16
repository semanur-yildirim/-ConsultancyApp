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

        public async Task<CategoryDescription> GetCategoryDescriptionByCategoryAsync(int categoryId)
        {
            return await _categoryDescriptionRepository.GetCategoryDescriptionByCategoryAsync(categoryId);
        }
    }
}
