using ConsultancyApp.Entity.Concrete;

namespace ConsultancyApp.MVC.Models.ViewModels
{
    public class CategoriesModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public CategoryDescription CategoryDescription { get; set; }
        public List<Psychologist> Psychologist { get; set; }
    }
}
