using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Abstract
{
    public interface IPsychologistService
    {
        Task CreateAsync(Psychologist psychologist);
        Task<Psychologist> GetByIdAsync(int id);
        Task<List<Psychologist>> GetAllAsync();
        void Update(Psychologist psychologist);
        void Delete(Psychologist psychologist);
        Task<Psychologist> GetPsychologistFullDataByUserId(string userId);
        Task<List<Psychologist>> GetAllPsychologistDataAsync(bool ApprovedStatus=false);
        Task<Psychologist> GetPsychologistFullDataAsync(int id);
        Task<List<Psychologist>> GetPsychologistsByCategoriesAsync(int categoryId);
        Task<List<Psychologist>> GetPsychologistsByCustomerAsync(int customerId);
        Task CreatePsychologist(Psychologist psychologist, int[] SelectedCategories, Image image, PsychologistDescription psychologistDescription
            );
        Task UpdatePsychologist(Psychologist psychologist, int[] SelectedCategories, PsychologistDescription psychologistDescription, int[] psychologistCustomers);
    }
}
