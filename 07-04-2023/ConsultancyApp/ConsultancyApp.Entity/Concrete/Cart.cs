using ConsultancyApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class Cart
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; }

    }
}
