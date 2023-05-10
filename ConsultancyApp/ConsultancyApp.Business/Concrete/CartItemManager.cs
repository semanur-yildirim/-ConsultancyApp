using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Concrete
{
    public class CartItemManager:ICartItemService
    {
        ICartItemRepository _cartItemRepository;
        public CartItemManager(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task ChangeQuantityAsync(int cartItemId, int quantity)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            await _cartItemRepository.ChangeQuantityAsync(cartItem, quantity);
        }

        public void ClearCart(int cartId)
        {
            _cartItemRepository.CleanCart(cartId);
        }

        public void Delete(CartItem cartItem)
        {
            _cartItemRepository.Delete(cartItem);
        }

        public async Task<CartItem> GetByIdAsync(int id)
        {
            return await _cartItemRepository.GetByIdAsync(id);
        }
    }
}
