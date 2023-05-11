using ConsultancyApp.Entity.Abstract;
using ConsultancyApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class Request : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public decimal? Price { get; set; }
        public string Gender { get; set; }
        public DateTime GraduationYear { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string About { get; set; }
        public Image Image { get; set; }
        public List<RequestCategory> RequestCategories { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}

