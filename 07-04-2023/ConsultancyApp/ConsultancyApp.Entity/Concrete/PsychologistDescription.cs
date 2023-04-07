using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class PsychologistDescription
    {
        public int PsychologistId { get; set; }
        public Psychologist Psychologist { get; set; }
        public int? GraduationYear { get; set; }    
        public string Experience { get; set; }  
        public string Education { get; set; }
        public string Gender { get; set; }  
        public DateTime BirthDate { get; set; }
        public string About { get; set; }
    }
}   
