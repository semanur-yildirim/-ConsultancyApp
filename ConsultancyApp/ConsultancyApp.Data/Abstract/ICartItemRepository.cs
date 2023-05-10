using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Abstract
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        void CleanCart(int cartId);
        Task ChangeQuantityAsync(CartItem cartItem, int quantity);
    }
}
