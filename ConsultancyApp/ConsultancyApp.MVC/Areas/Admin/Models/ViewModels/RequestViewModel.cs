using ConsultancyApp.Entity.Concrete;

namespace ConsultancyApp.MVC.Areas.Admin.Models.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }
       
        public bool IsApproved { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public string Url { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        //public decimal? Price { get; set; }
        public string Name { get; set; }
        //public string Gender { get; set; }
        //public DateTime GraduationYear { get; set; }
        //public string Experience { get; set; }
        //public string Education { get; set; }
        //public string About { get; set; }
        //public string Email { get; set; }
        //public string UserName { get; set; }
        public Image Image { get; set; }
        //public string Password { get; set; }
        //public int[] SelectedCategories { get; set; }
        public List<Category> Categories { get; set; }
    }
}
