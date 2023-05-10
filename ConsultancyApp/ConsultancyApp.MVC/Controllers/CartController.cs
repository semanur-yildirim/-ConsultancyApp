using AspNetCoreHero.ToastNotification.Abstractions;
using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConsultancyApp.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;
        private readonly INotyfService _notyfService;

        public CartController(UserManager<User> userManager, ICartService cartService, ICartItemService cartItemService, IOrderService orderService, INotyfService notyfService)
        {
            _userManager = userManager;
            _cartService = cartService;
            _cartItemService = cartItemService;
            _orderService = orderService;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var cart=await _cartService.GetCartByUserId(userId);
            CartViewModel cartViewModel = new CartViewModel
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(ci => new CartItemViewModel
                {
                    CartItemId = ci.Id,
                    PsychologistId = ci.PsychologistId,
                    PsychologistName = ci.Psychologist.Name,
                    Quantity = ci.Quantity,
                    PsychologistUrl = ci.Psychologist.Url,
                    ItemPrice = ci.Psychologist.Price,
                    ImageUrl = ci.Psychologist.Image.Url
                }).ToList()
            };           
            return View(cartViewModel);
        }

    }
}
