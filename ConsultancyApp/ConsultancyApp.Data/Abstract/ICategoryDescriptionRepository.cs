using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Abstract
{
    public interface ICategoryDescriptionRepository:IGenericRepository<CategoryDescription>
    {
        Task<CategoryDescription> GetCategoryDescriptionByCategoryAsync(string categoryurl);
    }
}
