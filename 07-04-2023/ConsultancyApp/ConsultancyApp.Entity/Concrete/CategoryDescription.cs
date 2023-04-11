using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class CategoryDescription
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string What { get; set; }
        public string How { get; set; }
        public string HowLong { get; set; }
        public string ForWho { get; set; }
        public string Purpose { get; set;}
        public string PositiveEffect { get; set; }
    }
}
