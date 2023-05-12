using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Abstract
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        Task<List<Customer>> GetAllCustomerFullDataAsycn(bool IsApprovedStatus = false);
        Task<Customer> GetCustomerFullDataAsync(int id);
        Task<Customer> GetCustomerFullDataByUserId(string userId);
        Task UpdateCustomer(Customer customer);
        Task<List<Customer>> GetCustomerByPsychologist(int psychologistId);
    }
}
