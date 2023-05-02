using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConsultancyApp.MVC.Areas.Admin.Models.ViewModels
{
    public class PsychologistAddViewModel
    {
        public int Id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        [DisplayName(" Ücret Alanı")]
        [Required(ErrorMessage = "Ücret alanı boş bırakılamaz")]
        public decimal? Price { get; set; }

        [DisplayName(" İsim")]
        [Required(ErrorMessage = "İsim alanı boş bırakılamaz")]
        public string Name { get; set; }

        [DisplayName(" Cinsiyet Alanı")]
        [Required(ErrorMessage = "Cinsiyet alanı boş bırakılamaz")]
        public string Gender { get; set; }
        public List<SelectListItem> GenderSelectList { get; set; }
        [DisplayName("  Profil Fotoğrafı")]
        [Required(ErrorMessage = "Profil Fotoğrafı boş bırakılamaz")]
        public IFormFile Image { get; set; }

        #region Description
        [DisplayName("Mezuniyet Yılı")]
        [Required(ErrorMessage = "Mezuniyet alanı boş bırakılamaz")]
        public DateTime GraduationYear { get; set; }

        [DisplayName("Deneyim")]
        [Required(ErrorMessage = "Deneyim alanı boş bırakılamaz")]
        public string Experience { get; set; }
        [DisplayName("Eğitim")]
        [Required(ErrorMessage = "Eğitim alanı boş bırakılamaz")]
        public string Education { get; set; }

        [DisplayName("Hakkında")]
        [Required(ErrorMessage = "Hakkında alanı boş bırakılamaz")]
        public string About { get; set; }
        #endregion
        [Required(ErrorMessage = "En az bir kategori seçilmelidir")]
        [DisplayName(" Kategoriler ")]
        public int[] SelectedCategories { get; set; }

        public List<Category> Categories { get; set; }
        public UserViewModel User { get; set; }
    }
}
