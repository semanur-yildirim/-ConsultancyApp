using ConsultancyApp.Entity.Concrete;

namespace ConsultancyApp.MVC.Areas.Admin.Models.ViewModels
{
    public class CustomerUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public UserViewModel User { get; set; }
        public List<PsychologistViewModel> Psychologists { get; set; }
    }
}
