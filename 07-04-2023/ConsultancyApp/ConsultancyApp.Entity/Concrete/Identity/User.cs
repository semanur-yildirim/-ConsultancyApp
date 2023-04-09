using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete.Identity
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Psychologist Psychologist { get; set; }
        public int PsychologistId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
