using System.ComponentModel.DataAnnotations;

namespace ConsultancyApp.MVC.Models.ViewModels
{
    public class CartItemViewModel
    {
        public int CartItemId { get; set; }
        public int PsychologistId { get; set; }
        public string PsychologistName { get; set; }
        public string PsychologistUrl { get; set; }
        public decimal? ItemPrice { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Boş bırakılamaz")]
        [Range(1,8)]
        public int Quantity { get; set; }
    }
}
