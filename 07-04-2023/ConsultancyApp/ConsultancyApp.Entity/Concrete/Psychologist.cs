using ConsultancyApp.Entity.Abstract;
using ConsultancyApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class Psychologist : IBaseEntity 
    {
        public int Id { get ; set ; }
        public DateTime CreatedDate { get; set ; }
        public DateTime ModifiedDate { get; set ; }
        public bool IsApproved { get; set ; }
        public string Url { get ; set ; }
        public decimal? Price { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public List<PsychologistCategory> PsychologistCategory { get; set; }    
        public PsychologistDescription PsychologistDescription { get; set; }
        public List<PsychologistCustomer> PsychologistCustomer { get; set; }
        public Image Image { get; set; }

        public string userId { get; set; }
        public User user { get; set; }


    }
}
