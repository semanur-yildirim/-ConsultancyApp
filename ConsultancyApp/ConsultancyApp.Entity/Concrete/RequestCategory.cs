using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class RequestCategory
    {
        public Request Request { get; set; }
        public int RequestId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
