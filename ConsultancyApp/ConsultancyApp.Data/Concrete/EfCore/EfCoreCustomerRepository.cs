using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Data.Concrete.EfCore.Context;
using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Concrete.EfCore
{
    public class EfCoreCustomerRepository : EfCoreGenericRepository<Customer>, ICustomerRepository
    {
        public EfCoreCustomerRepository(ConsultancyAppContext _appContext) : base(_appContext)
        {
        }
        ConsultancyAppContext AppContext
        {
            get { return _dbContext as ConsultancyAppContext; }
        }
        public async Task<List<Customer>> GetAllCustomerFullDataAsycn(bool IsApprovedStatus = false)
        {
            var customer =  AppContext.Customer.Include(p => p.PsychologistCustomer).ThenInclude(p => p.Psychologist).AsQueryable();
            if (IsApprovedStatus)
            {
                customer=customer.Where(p => p.IsApproved == IsApprovedStatus);
            }
               
            return await customer.ToListAsync();
        }

        public async Task<List<Customer>> GetCustomerByPsychologist(int psychologistId)
        {
            var customers = await AppContext.Customer.Include(c => c.PsychologistCustomer).ThenInclude(pc => pc.Psychologist).Where(p => p.PsychologistCustomer.Any(pc => pc.PsychologistId == psychologistId)).ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerFullDataAsync(int id)
        {
            var customer = await AppContext.Customer.Where(c => c.Id == id).FirstOrDefaultAsync();
            return customer;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var updateCustomer = await AppContext.Customer.Include(c => c.PsychologistCustomer).FirstOrDefaultAsync(c=>c.Id==customer.Id);
            updateCustomer.Name=customer.Name;
            updateCustomer.ModifiedDate=customer.ModifiedDate;
            updateCustomer.IsApproved= customer.IsApproved;
            updateCustomer.Url=customer.Url;
            updateCustomer.IsApproved = customer.IsApproved;
            updateCustomer.Address= customer.Address;
            updateCustomer.PsychologistCustomer = customer.PsychologistCustomer;
            AppContext.Update(customer);
            await AppContext.SaveChangesAsync();
        }
    }
}
