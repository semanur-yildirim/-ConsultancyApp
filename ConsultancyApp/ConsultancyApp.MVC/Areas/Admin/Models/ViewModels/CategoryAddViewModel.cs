using ConsultancyApp.Entity.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ConsultancyApp.MVC.Areas.Admin.Models.ViewModels
{
    public class CategoryAddViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [DisplayName("Onaylı mı?")]

        public bool IsApproved { get; set; }
        public string Url { get; set; }
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "Kategori adı boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Kategori adı en az 5 karakter olmalıdır")]
        [MaxLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olmalıdır")]
        public string Name { get; set; }
        [DisplayName("Özet")]
        [Required(ErrorMessage = "Özet boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = " Özet en az 5 karakter olmalıdır")]
        [MaxLength(500, ErrorMessage = " Özet en fazla 500 karakter olmalıdır")]
        public string Summary { get; set; }

        [DisplayName("Nedir?")]
        [Required(ErrorMessage = "Nedir boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Nedir Alanı en az 5 karakter olmalıdır")]
        [MaxLength(500, ErrorMessage = "Nedir Alanı en fazla 500 karakter olmalıdır")]
        public string What { get; set; }

        [DisplayName("Nasıl Uygulanır?")]
        [Required(ErrorMessage = "Nasıl uygulanır alanı boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Nasıl uygulanır alanı en az 5 karakter olmalıdır")]
        [MaxLength(500, ErrorMessage = "Nasıl uygulanır alanı en fazla 500 karakter olmalıdır")]
        public string How { get; set; }

        [DisplayName("Ne Kadar Sürer?")]
        [Required(ErrorMessage = "Ne Kadar Sürer alanı boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Ne Kadar Sürer alanı en az 5 karakter olmalıdır")]
        [MaxLength(500, ErrorMessage = "Ne Kadar Sürer alanı en fazla 500 karakter olmalıdır")]
        public string HowLong { get; set; }

        [DisplayName("Kimin İçin?")]
        [Required(ErrorMessage = "Kimin için alanı boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Kimin için alanı en az 5 karakter olmalıdır")]
        [MaxLength(500, ErrorMessage = "Kimin için alanı en fazla 500 karakter olmalıdır")]
        public string ForWho { get; set; }

        [DisplayName("Amaç Nedir?")]
        [Required(ErrorMessage = "Amaç nedir alanı boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Amaç nedir alanı en az 5 karakter olmalıdır")]
        [MaxLength(500, ErrorMessage = "Amaç nedir alanı en fazla 500 karakter olmalıdır")]
        public string Purpose { get; set; }

        [DisplayName("Etkisi")]
        [Required(ErrorMessage = "Etkisi alanı boş bırakılmamalıdır")]
        [MinLength(5, ErrorMessage = "Etkisi alanı en az 5 karakter olmalıdır")]
        [MaxLength(500, ErrorMessage = "Etkisi alanı en fazla 500 karakter olmalıdır")]
        public string PositiveEffect { get; set; }
    }
}
