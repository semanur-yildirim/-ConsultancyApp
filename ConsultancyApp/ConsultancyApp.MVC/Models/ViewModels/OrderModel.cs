using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsultancyApp.MVC.Models.ViewModels
{
    public class OrderModel
    {
        public int Id { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad alanı boş bırakılmamalıdır.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad alanı boş bırakılmamalıdır.")]
        public string LastName { get; set; }

        [DisplayName("Adres")]
        [Required(ErrorMessage = "Adres alanı boş bırakılmamalıdır.")]
        public string Address { get; set; }
        [DisplayName("Eposta")]
        [Required(ErrorMessage = "Eposta alanı boş bırakılmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }
        public CartViewModel Cart { get; set; }
        public List<CartItemViewModel> OrderItems { get; set; }


        //Kredi Kartı ile ilgili properties
        [DisplayName("Kartın Üzerinde Ad Soyad")]
        [Required(ErrorMessage = "Ad soyad zorunludur")]
        public string CardName { get; set; }

        [DisplayName("Kart Numarası")]
        [Required(ErrorMessage = "Ad soyad zorunludur")]
        public string CardNumber { get; set; }

        [DisplayName("Geçerlilik Tarihi Ay")]
        [Required(ErrorMessage = "Ay bilgisi zorunludur")]
        public string ExpirationMonth { get; set; }

        [DisplayName("Geçerlilik Tarihi Yıl")]
        [Required(ErrorMessage = "Yıl bilgisi zorunludur")]
        public string ExpirationYear { get; set; }

        [DisplayName("Cvc No")]
        [Required(ErrorMessage = "Cvc bilgisi zorunludur")]
        public string Cvc { get; set; }
    }
}
