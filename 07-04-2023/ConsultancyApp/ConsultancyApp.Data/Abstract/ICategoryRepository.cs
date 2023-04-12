﻿using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<List<Category>> GetCategoriesAsync(bool ApprpvedStatus);
        Task<List<Category>> GetCategoriesByPsyhologist(int Psychologist);
    }
}