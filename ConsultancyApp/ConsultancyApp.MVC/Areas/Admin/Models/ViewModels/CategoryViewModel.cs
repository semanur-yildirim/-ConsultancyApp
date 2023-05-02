using ConsultancyApp.Entity.Concrete;

namespace ConsultancyApp.MVC.Areas.Admin.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public List<PsychologistViewModel> Psychologists { get; set; }
    }
}
