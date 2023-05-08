using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsultancyApp.MVC.Areas.Admin.Models.ViewModels
{
    public class CustomerAddViewModel
    {
        public int Id { get; set; }
        [DisplayName(" İsim")]
        [Required(ErrorMessage = "İsim alanı boş bırakılamaz")]
        public string Name { get; set; }
        [DisplayName("Adres")]
        [Required(ErrorMessage = "Adres alanı boş bırakılamaz")]
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public UserViewModel User { get; set; }
        public EnumType Type { get; set; } = EnumType.Customer;
    }
}
