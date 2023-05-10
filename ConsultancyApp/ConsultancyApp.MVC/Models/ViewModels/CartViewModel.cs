namespace ConsultancyApp.MVC.Models.ViewModels
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public decimal? TotalPrice()
        {
            return CartItems.Sum(ci => ci.ItemPrice * ci.Quantity);
        }
    }
}
