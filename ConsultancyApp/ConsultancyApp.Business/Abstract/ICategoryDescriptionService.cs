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
        Task<CategoryDescription> GetCategoryDescriptionByCategoryAsync(int categoryId);
    }
}
