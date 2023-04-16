using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Concrete
{
    public class PsychologistManager:IPsychologistService
    {
        private IPsychologistRepository _psychologistRepository;

        public PsychologistManager(IPsychologistRepository psychologistRepository)
        {
            _psychologistRepository = psychologistRepository;
        }

        public async Task CreateAsync(Psychologist psychologist)
        {
            await _psychologistRepository.CreateAsync(psychologist);
        }

        public async Task CreatePsychologist(Psychologist psychologist, int[] SelectedCategories, Image image, PsychologistDescription psychologistDescription)
        {
            await _psychologistRepository.CreatePsychologist(psychologist,SelectedCategories,image, psychologistDescription);
        }

        public  void Delete(Psychologist psychologist)
        {
           _psychologistRepository.Delete(psychologist);
        }

        public async Task<List<Psychologist>> GetAllAsync()
        {
            return await _psychologistRepository.GetAllAsync();

        }

        public async Task<List<Psychologist>> GetAllPsychologistDataAsync(bool ApprovedStatus)
        {
            return await _psychologistRepository.GetAllPsychologistDataAsync(ApprovedStatus);
        }

        public async Task<Psychologist> GetByIdAsync(int id)
        {
            return await _psychologistRepository.GetByIdAsync(id);
        }

        public async Task<Psychologist> GetPsychologistFullDataAsync(int id)
        {
            return await _psychologistRepository.GetPsychologistFullDataAsync(id);

        }

        public async Task<List<Psychologist>> GetPsychologistsByCategoriesAsync(int categoryId)
        {
            return await _psychologistRepository.GetPsychologistsByCategoriesAsync(categoryId);
        }

        public async Task<List<Psychologist>> GetPsychologistsByCustomerAsync(int customerId)
        {
            return await _psychologistRepository.GetPsychologistsByCustomerAsync(customerId);
        }

        public  void Update(Psychologist psychologist)
        {
            _psychologistRepository.Update(psychologist);
        }

        public async Task UpdatePsychologist(Psychologist psychologist, int[] SelectedCategories, PsychologistDescription psychologistDescription, int[] psychologistCustomers)
        {
            await _psychologistRepository.UpdatePsychologist(psychologist, SelectedCategories, psychologistDescription, psychologistCustomers);
        }
    }
}
