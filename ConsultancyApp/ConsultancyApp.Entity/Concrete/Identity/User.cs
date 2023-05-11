using ConsultancyApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace ConsultancyApp.Entity.Concrete.Identity
{
    public class User: IdentityUser
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NormalizedName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public EnumType Type { get; set; }
        public Psychologist? Psychologist { get; set; }
        public Customer? Customer { get; set; }
        public Request? Request { get; set; }
        public Cart Cart { get; set; }
        public Order? Order { get; set; }
    }
    public enum EnumType
    {
        Admin = 0,
        Psychologist = 1,
        Customer = 2,
        Request=3
    }
}
