using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Abstract
{
    public interface OrderRepository :IGenericRepository<Order>
    {
        Task<List<Order>> GetAllOrdersAsync(string userId=null);
    }
}
