using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Abstract
{
    public interface IPsychologistRepository:IGenericRepository<Psychologist>
    {
        Task<List<Psychologist>> GetAllPsychologistDataAsync(bool ApprovedStatus=false);
        Task<Psychologist> GetPsychologistFullDataAsync(int id);
        Task<Psychologist> GetPsychologistFullDataByUserId(string userId);
        Task<List<Psychologist>> GetPsychologistsByCategoriesAsync(int categoryId);
        Task<List<Psychologist>> GetPsychologistsByCustomerAsync(int customerId);

        Task CreatePsychologist(Psychologist psychologist, int[] SelectedCategories, Image image,PsychologistDescription psychologistDescription
            );
        Task UpdatePsychologist(Psychologist psychologist, int[] SelectedCategories, PsychologistDescription psychologistDescription,int[] psychologistCustomers);
    }
}

