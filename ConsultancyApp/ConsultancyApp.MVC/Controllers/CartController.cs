using AspNetCoreHero.ToastNotification.Abstractions;
using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.MVC.Models.ViewModels;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
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
        private readonly ICustomerService _customerService;
        public CartController(UserManager<User> userManager, ICartService cartService, ICartItemService cartItemService, IOrderService orderService, INotyfService notyfService, ICustomerService customerService)
        {
            _userManager = userManager;
            _cartService = cartService;
            _cartItemService = cartItemService;
            _orderService = orderService;
            _notyfService = notyfService;
            _customerService = customerService;
        }
        #region Index
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _cartService.GetCartByUserId(userId);
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
        #endregion
        #region AddToCart
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, int Quantity)
        {
            var userId = _userManager.GetUserId(User);
            await _cartService.AddToCart(userId, id, Quantity);
            _notyfService.Success("Ürün sepetinize başarıyla eklenmiştir");
            return RedirectToAction("Index");
        }
        #endregion
        #region DeleteFromCart
        public async Task<IActionResult> DeleteFromCart(int id)
        {
            var cartItem = await _cartItemService.GetByIdAsync(id);
            _cartItemService.Delete(cartItem);
            _notyfService.Success(" Seans Sepettinizden kaldırılmıştır", 2);
            return RedirectToAction("Index");
        }
        #endregion
        #region ClearCart
        public  IActionResult ClearCart(int id)
        {
            _cartItemService.ClearCart(id);
            return RedirectToAction("Index");
        }
        #endregion
        #region Checkout
        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var customer = _customerService.GetCustomerFullDataByUserId(user.Id);

            var cart = await _cartService.GetCartByUserId(user.Id);
            OrderModel orderViewModel = new OrderModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = customer.Result.Address,
                Email = user.Email,
                Cart = new CartViewModel
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(ci => new CartItemViewModel
                    {
                        CartItemId = ci.Id,
                        PsychologistId = ci.PsychologistId,
                        PsychologistName = ci.Psychologist.Name,
                        ItemPrice = ci.Psychologist.Price,
                        Quantity = ci.Quantity,
                        ImageUrl = ci.Psychologist.Image.Url
                    }).ToList(),
                }
            };
            return View(orderViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderModel orderModel)
        {
            var userId = _userManager.GetUserId(User);
            var cart = await _cartService.GetCartByUserId(userId);
            if(ModelState.IsValid)
            {
                orderModel.Cart = new CartViewModel
                {
                    CartId = cart.Id,
                    CartItems=cart.CartItems.Select(ci=>new CartItemViewModel
                    {

                        CartItemId = ci.Id,
                        PsychologistId = ci.PsychologistId,
                        PsychologistName = ci.Psychologist.Name,
                        PsychologistUrl = ci.Psychologist.Url,
                        ItemPrice = ci.Psychologist.Price,
                        ImageUrl = ci.Psychologist.Image.Url,
                        Quantity = ci.Quantity
                    }).ToList()
                };
                if (!CardNumberControl(orderModel.CardNumber))
                {
                    _notyfService.Error("Geçersiz kart numarası!");
                    return View(orderModel);
                }
                Payment payment = PaymentProcess(orderModel);
                if (payment.Status == "success")
                {
                  // SaveOrder(orderModel, userId);
                _cartItemService.ClearCart(orderModel.Cart.CartId);
                _notyfService.Success("Ödemeniz alınmış ve siparişiniz oluşturulmuştur!");
                return RedirectToAction("Index", "Home");
                }
                _notyfService.Error("Bir sorun oluştu!");

            }
            orderModel.Cart = new CartViewModel
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(ci => new CartItemViewModel
                {
                    CartItemId = ci.Id,
                    PsychologistId = ci.PsychologistId,
                    PsychologistName = ci.Psychologist.Name,
                    PsychologistUrl = ci.Psychologist.Url,
                    ItemPrice = ci.Psychologist.Price,
                    ImageUrl = ci.Psychologist.Image.Url,
                    Quantity = ci.Quantity
                }).ToList()
            };
            return View(orderModel);
        }
        #endregion
        [NonAction]
        private bool CardNumberControl(string cardNumber)
        {
            #region MyRegion
            /* -cardNumber'ı boşluk ve tire'den arındıracağız.
             * -cardNumber uzunluk kontrolünü yapacağız.
             * -Sayısal değer kontrolü yapacağız.
             * -Luhn algoritmasına uygunluğunu test edeceğiz
             */
            cardNumber = cardNumber.Replace("-", "").Replace(" ", "");
            if (cardNumber.Length != 16) return false;
            foreach (var chr in cardNumber)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            int oddTotal = 0;
            int ovenTotal = 0;
            for (int i = 0; i < cardNumber.Length; i+=2)
            {
                int nextOddNumber = Convert.ToInt32(cardNumber[i].ToString());
                int nextOvenNumber = Convert.ToInt32(cardNumber[i + 1].ToString());
                int addedOddNumber = nextOddNumber * 2;
                addedOddNumber = addedOddNumber >= 10 ? addedOddNumber - 9 : addedOddNumber;
                oddTotal += addedOddNumber;
                ovenTotal += nextOvenNumber;
            }
            int total = oddTotal + ovenTotal;
            bool isValidNumber = total % 10 == 0 ? true : false;
            return isValidNumber;
            #endregion
        }

        private Payment PaymentProcess(OrderModel orderViewModel)
        {
            #region Payment Options Created
            Options options = new Options();
            options.ApiKey = "sandbox-df0rPH1EkY06JiQnzHkQDorRbMY7BJ0X";
            options.SecretKey = "sandbox-CvCyjJzzPtxJPo5DU4k6J5jVOejAcjt6";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";
            #endregion
            #region Create Payment Request
            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = new Random().Next(1000000, 9999999).ToString(),
                Price = Convert.ToInt32(orderViewModel.Cart.TotalPrice()).ToString(),
                PaidPrice = Convert.ToInt32(orderViewModel.Cart.TotalPrice()).ToString(),
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = orderViewModel.Cart.CartId.ToString(),
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                PaymentCard = new PaymentCard
                {
                    CardHolderName = orderViewModel.CardName,
                    CardNumber = orderViewModel.CardNumber,
                    ExpireMonth = orderViewModel.ExpirationMonth,
                    ExpireYear = orderViewModel.ExpirationYear,
                    Cvc = orderViewModel.Cvc,
                    RegisterCard = 0
                },
                Buyer = new Buyer
                {
                    Id = "BY999",
                    Name = orderViewModel.FirstName,
                    Surname = orderViewModel.LastName,
                    Email = orderViewModel.Email,
                    IdentityNumber = "87955588899",
                    RegistrationAddress = orderViewModel.Address,
                    Ip = "84.99.155.212",
                    Country = "Türkiye",
                    ZipCode = "34700",
                    City="İstanbul"
                },
                ShippingAddress = new Address
                {
                    ContactName = orderViewModel.FirstName + " " + orderViewModel.LastName,
                    Country = "Türkiye",
                    Description = orderViewModel.Address,
                    City = "İstanbul"

                },
                BillingAddress = new Address
                {
                    ContactName = orderViewModel.FirstName + " " + orderViewModel.LastName,
                    Country = "Türkiye",
                    Description = orderViewModel.Address,
                    City = "İstanbul"

                }
            };
            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;
            foreach (var item in orderViewModel.Cart.CartItems)
            {
                basketItem = new BasketItem
                {
                    Id = item.CartItemId.ToString(),
                    Name = item.PsychologistName.ToString(),
                    Category1 = "Ürün",
                    ItemType = BasketItemType.PHYSICAL.ToString(),
                    Price = Convert.ToInt32(item.ItemPrice * item.Quantity).ToString()
                };
                basketItems.Add(basketItem);
            }
            request.BasketItems = basketItems;
            #endregion
            Payment payment = Payment.Create(request, options);
            return payment;
        }
    }
}
