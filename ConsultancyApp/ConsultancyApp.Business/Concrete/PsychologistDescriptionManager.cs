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
    public class PsychologistDescriptionManager : IPsychologistDescriptionService
    {
        private IPsychologistDescriptionRepository _psychologistDescriptionRepository;

        public PsychologistDescriptionManager(IPsychologistDescriptionRepository psychologistDescriptionRepository)
        {
            _psychologistDescriptionRepository = psychologistDescriptionRepository;
        }

        public async Task CreateAsync(PsychologistDescription psychologistDescription)
        {
            await _psychologistDescriptionRepository.CreateAsync(psychologistDescription);
        }

        public void Delete(PsychologistDescription psychologistDescription)
        {
           _psychologistDescriptionRepository.Delete(psychologistDescription);
        }

        public async Task<List<PsychologistDescription>> GetAllAsync()
        {
            return await _psychologistDescriptionRepository.GetAllAsync();
        }

        public async Task<PsychologistDescription> GetByIdAsync(int id)
        {
           return  await _psychologistDescriptionRepository.GetByIdAsync(id);
        }

        public async Task<PsychologistDescription> GetPsychologistDescriptionByPsychologistAsync(int psychologistId)
        {
            return await _psychologistDescriptionRepository.GetPsychologistDescriptionByPsychologistAsync(psychologistId);
        }

        public void Update(PsychologistDescription psychologistDescription)
        {
            _psychologistDescriptionRepository.Update(psychologistDescription);
        }
    }
}
