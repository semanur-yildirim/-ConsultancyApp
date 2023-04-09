using ConsultancyApp.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NormalizedName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public EnumOrderState OrderState { get; set; }
        public List<OrderItem> OrderItems { get; set; }


    }
    public enum EnumOrderState
    {
        Waiting = 0,
        Unpaid = 1,
        Completed = 2
    }
}
