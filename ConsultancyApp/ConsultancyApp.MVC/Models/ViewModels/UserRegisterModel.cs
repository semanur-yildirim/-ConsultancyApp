using ConsultancyApp.Entity.Concrete.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsultancyApp.MVC.Models.ViewModels
{
    public class UserRegisterModel
    {

        [DisplayName("Adı")]
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz")]
        public string FirstName { get; set; }

        [DisplayName("Soyadı")]
        [Required(ErrorMessage = "Soyadı alanı boş bırakılamaz")]
        public string LastName { get; set; }

        [DisplayName("Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        public string UserName { get; set; }

        [DisplayName("Eposta")]
        [Required(ErrorMessage = "Eposta adresi boş bırakılamaz")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Parola")]
        [Required(ErrorMessage = "Parola alanı zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Parola Tekrar")]
        [Required(ErrorMessage = "Parola tekrar alanı zorunludur")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "İki parola aynı olmalıdır!")]
        public string RePassword { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; }=DateTime.Now;
    }
}
