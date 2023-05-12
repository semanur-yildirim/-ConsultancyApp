using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task CreateAsync(Customer customer)
        {
            await _customerRepository.CreateAsync(customer);
        }

        public void Delete(Customer customer)
        {
            _customerRepository.Delete(customer);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<List<Customer>> GetAllCustomerFullDataAsycn(bool IsApprovedStatus=false)
        {
            return await _customerRepository.GetAllCustomerFullDataAsycn(IsApprovedStatus);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task<List<Customer>> GetCustomerByPsychologist(int psychologistId)
        {
            return await _customerRepository.GetCustomerByPsychologist(psychologistId);
        }

        public async Task<Customer> GetCustomerFullDataAsync(int id)
        {
            return await _customerRepository.GetCustomerFullDataAsync(id);
        }

        public async Task<Customer> GetCustomerFullDataByUserId(string userId)
        {
            return await _customerRepository.GetCustomerFullDataByUserId(userId);
        }

        public void Update(Customer customer)
        {
            _customerRepository.Update(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await _customerRepository.UpdateCustomer(customer);
        }
    }
}
