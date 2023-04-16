using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class PsychologistCategory
    {
        public Psychologist Psychologist { get; set; }
        public int PsychologistId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
