using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.Entity.Concrete;

namespace ConsultancyApp.MVC.Areas.Admin.Models.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public List<PsychologistViewModel> Psychologists { get; set; }

    }
}
