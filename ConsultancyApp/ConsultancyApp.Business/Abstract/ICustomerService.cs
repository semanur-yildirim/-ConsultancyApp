using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Abstract
{
    public interface ICustomerService
    {
        Task CreateAsync(Customer customer);
        Task<Customer> GetByIdAsync(int id);
        Task<List<Customer>> GetAllAsync();
        void Update(Customer customer);
        void Delete(Customer customer);
        Task<List<Customer>> GetAllCustomerFullDataAsycn(bool IsApprovedStatus);
        Task<Customer> GetCustomerFullDataAsync(int id);
        Task UpdateCustomer(Customer customer);
        Task<List<Customer>> GetCustomerByPsychologist(int psychologistId);
    }
}
