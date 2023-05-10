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
    public class EfCoreCartItemRepository : EfCoreGenericRepository<CartItem>, ICartItemRepository
    {
        public EfCoreCartItemRepository(ConsultancyAppContext _appContext) : base(_appContext)
        {
        }
        ConsultancyAppContext AppContext
        {
            get { return _dbContext as ConsultancyAppContext; }
        }
        
        public void CleanCart(int cartId)
        {
            AppContext.CartItems.Where(ci => ci.CartId == cartId).ExecuteDelete();
        }
        public async Task ChangeQuantityAsync(CartItem cartItem, int quantity)
        {
            cartItem.Quantity = quantity;
            AppContext.CartItems.Update(cartItem);
            await AppContext.SaveChangesAsync();
        }
    }

}
