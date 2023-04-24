using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class PsychologistDescription
    {
        public int Id { get; set; }
        public Psychologist Psychologist { get; set; }
        public int PsychologistId { get; set; }
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
    }
}   
