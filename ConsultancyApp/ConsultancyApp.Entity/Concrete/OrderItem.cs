using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Psychologist Psychologist { get; set; }
        public int PsychologistId { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }

    }
}
