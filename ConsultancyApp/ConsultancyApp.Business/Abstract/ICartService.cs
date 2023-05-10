using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Abstract
{
    public interface ICartService
    {
        Task InitializeCart(string userId);
        Task AddToCart(string userId, int psychologistId, int quantity);
        Task<Cart> GetByIdAsync(int id);
        Task<Cart> GetCartByUserId(string userId);
    }
}

