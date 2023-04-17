using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Data.Concrete.EfCore.Context;
using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Concrete.EfCore
{
    public class EfCoreCategoryDescriptionRepository : EfCoreGenericRepository<CategoryDescription>, ICategoryDescriptionRepository
    {
        public EfCoreCategoryDescriptionRepository(ConsultancyAppContext _appContext) : base(_appContext)
        {
        }
        ConsultancyAppContext AppContext
        {
            get { return _dbContext as ConsultancyAppContext; }
        }
        public async Task<CategoryDescription> GetCategoryDescriptionByCategoryAsync(int categoryId)
        {
            return await AppContext.CategoryDescription.Where(cd => cd.CategoryId == categoryId).FirstOrDefaultAsync();
        }
    }
}
