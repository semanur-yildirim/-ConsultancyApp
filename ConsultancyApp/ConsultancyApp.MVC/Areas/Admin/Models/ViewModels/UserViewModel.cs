using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ConsultancyApp.Entity.Concrete.Identity;

namespace ConsultancyApp.MVC.Areas.Admin.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "Ad zorunludur")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Soyad zorunludur")]
        public string LastName { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı zorunludur")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email zorunludur")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Email Onayı")]
        public bool EmailConfirmed { get; set; }

        [DisplayName("Roller")]
        public EnumType Type { get; set; }
        [DisplayName("Parola")]
        [Required(ErrorMessage = "Parola alanı boş bırakılmamalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public PsychologistUpdateViewModel Psychlogist { get; set; }
    }
}
