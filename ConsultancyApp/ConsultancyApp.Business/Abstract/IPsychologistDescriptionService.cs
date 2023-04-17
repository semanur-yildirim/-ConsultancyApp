using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Abstract
{
    public interface IPsychologistDescriptionService
    {
        Task CreateAsync(PsychologistDescription psychologistDescription);
        Task<PsychologistDescription> GetByIdAsync(int id);
        Task<List<PsychologistDescription>> GetAllAsync();
        void Update(PsychologistDescription psychologistDescription);
        void Delete(PsychologistDescription psychologistDescription);
        Task<PsychologistDescription> GetPsychologistDescriptionByPsychologistAsync(int psychologistId);

    }
}
