using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.Entity.Concrete;

namespace ConsultancyApp.MVC.Models.ViewModels
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public string userId { get; set; }
        public User user { get; set; }
        public List<PsychologistCustomer> PsychologistCustomer { get; set; }
        public int PsychologistId { get; set; }

    }
}
