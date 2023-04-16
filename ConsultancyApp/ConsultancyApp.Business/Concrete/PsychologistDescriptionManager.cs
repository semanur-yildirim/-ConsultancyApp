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

        public async Task<PsychologistDescription> GetPsychologistDescriptionByPsychologistAsync(int psychologistId)
        {
            return await _psychologistDescriptionRepository.GetPsychologistDescriptionByPsychologistAsync(psychologistId);
        }
    }
}
