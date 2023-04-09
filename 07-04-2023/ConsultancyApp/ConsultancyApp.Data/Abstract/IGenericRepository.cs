using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Abstract
{
    internal interface IGenericRepository<TEntity>
    {
        Task CreateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetAllAsync();
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

    }
}
