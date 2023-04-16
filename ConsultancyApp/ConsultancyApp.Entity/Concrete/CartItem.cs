using ConsultancyApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class CartItem
    {
        public int Id { get; set; }
        public Psychologist Psychologist { get; set; }
        public int PsychologistId { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }


    }

    
}
