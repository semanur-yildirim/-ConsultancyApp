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
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(DbContext _appContext) : base(_appContext)
        {
        }
        ConsultancyAppContext AppContext
        {
            get { return _dbContext as ConsultancyAppContext; }
        }

        public async Task<List<Category>> GetCategoriesAsync(bool ApprpvedStatus)
        {
           return await AppContext.Categories.Where(c=>c.IsApproved).ToListAsync();
        }
        public async Task<List<Category>> GetCategoriesByPsyhologist(int id)
        {
            List<Category> psychologists = await
                AppContext.Categories
            .Include(p => p.PsychologitstCategry)
            .ThenInclude(pc => pc.Psychologist).Where(p => p.PsychologitstCategry.Any(x => x.PsychologistId == id)).ToListAsync();
            return psychologists;
        }
    }
}
