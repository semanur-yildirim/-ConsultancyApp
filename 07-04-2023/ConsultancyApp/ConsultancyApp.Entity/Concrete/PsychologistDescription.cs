using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class PsychologistDescription
    {
        public int Id { get; set; }
        public int PsychologistId { get; set; }
        public Psychologist Psychologist { get; set; }
        public DateTime GraduationYear { get; set; }    
        public string Experience { get; set; }      
        public string Education { get; set; }
        public DateTime BirthDate { get; set; }
        public string About { get; set; }
    }
}   
