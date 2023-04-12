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
        Task<List<Psychologist>> GetAllPsychologistDataAsync(bool ApprovedStatus);
        Task<Psychologist> GetPsychologistFullData(int id);
        Task<List<Psychologist>> GetPsychologistsByCategories(int categoryId);
        Task<List<Psychologist>> GetPsychologistsByCustomer(int customerId);
    }
}
