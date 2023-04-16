using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Abstract
{
    public interface ICartRepository:IGenericRepository<Cart>
    {
        Task AddToCart(string userId, int psychologistId);
        Task<Cart> GetCartByUserId(int id);
    }
}
