using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Data.Concrete.EfCore.Context;
using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Concrete.EfCore
{
    public class EfCoreCartRepository:EfCoreGenericRepository<Cart>,ICartRepository
    {
        public EfCoreCartRepository(ConsultancyAppContext _appContext) : base(_appContext)
        {
        }
        ConsultancyAppContext AppContext
        {
            get { return _dbContext as ConsultancyAppContext; }
        }

        public async Task AddToCart(string userId, int psychologistId, int quantity)
        {
            var cart=await GetCartByUserId(userId);
            if(cart!=null)
            {
                var index = cart.CartItems.FindIndex(ci => ci.PsychologistId == psychologistId);
                if (index < 0)//Ürün daha önceden sepete eklenmemiþse
                {
                    cart.CartItems.Add(new CartItem
                    {
                        PsychologistId = psychologistId,
                        CartId = cart.Id,
                        Quantity = quantity
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }
                AppContext.Carts.Update(cart);
                await AppContext.SaveChangesAsync();
                
            }
        }

        public async Task<Cart> GetCartByUserId(string id)
        {
            return await AppContext.Carts.Include(c=>c.CartItems).ThenInclude(ci=>ci.Psychologist).ThenInclude(i=>i.Image).FirstOrDefaultAsync(c=>c.UserId== id);
        }
    }
}
