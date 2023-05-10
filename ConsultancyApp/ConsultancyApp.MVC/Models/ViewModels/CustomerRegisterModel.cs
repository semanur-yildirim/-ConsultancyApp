using ConsultancyApp.Entity.Concrete.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsultancyApp.MVC.Models.ViewModels
{
    public class CustomerRegisterModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Adres")]
        [Required(ErrorMessage = "Adres alanı boş bırakılamaz")]
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public string userId { get; set; }
        public UserRegisterModel User { get; set; }
        public EnumType Type { get; set; } = EnumType.Customer;
    }
}
