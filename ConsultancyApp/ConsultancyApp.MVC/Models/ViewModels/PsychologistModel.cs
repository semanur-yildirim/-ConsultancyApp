using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.Entity.Concrete;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsultancyApp.MVC.Models.ViewModels
{
    public class PsychologistModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        [DisplayName("Seans Ücreti")]
        [Required(ErrorMessage = "Ücret alanı boş bırakılamaz")]
        public decimal? Price { get; set; }
        [DisplayName(" Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet alanı boş bırakılamaz")]
        public string Gender { get; set; }
        public string Name { get; set; }
        public List<Category> categories { get; set; }
        public PsychologistDescription PsychologistDescription { get; set; }
        public Image Image { get; set; } 
    }
}
