using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.Entity.Concrete;

namespace ConsultancyApp.MVC.Models.ViewModels
{
    public class PsychologistModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public decimal? Price { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public List<Category> categories { get; set; }
        public PsychologistDescription PsychologistDescription { get; set; }
        public Image Image { get; set; } 
    }
}
