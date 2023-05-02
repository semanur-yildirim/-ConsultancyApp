using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsultancyApp.MVC.Areas.Admin.Models.ViewModels
{
    public class RoleAddViewModel
    {
        [DisplayName("Rol Adı")]
        [Required(ErrorMessage = "Rol adı zorunludur")]
        public string Name { get; set; }

        [DisplayName("Rol Açıklaması")]
        [Required(ErrorMessage = "Rol açıklaması zorunludur")]
        public string Description { get; set; }
    }
}
