using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class PsychologistCustomer
    {
        public Psychologist Psychologist { get; set; }
        public int PsychologistId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

    }
}
