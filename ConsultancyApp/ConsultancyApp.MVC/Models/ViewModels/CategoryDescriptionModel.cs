using ConsultancyApp.Entity.Concrete;

namespace ConsultancyApp.MVC.Models.ViewModels
{
    public class CategoryDescriptionModel
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Summary { get; set; }
        public string What { get; set; }
        public string How { get; set; }
        public string HowLong { get; set; }
        public string ForWho { get; set; }
        public string Purpose { get; set; }
        public string PositiveEffect { get; set; }
        public List<Psychologist> Psychologist { get; set; }
    }
}
