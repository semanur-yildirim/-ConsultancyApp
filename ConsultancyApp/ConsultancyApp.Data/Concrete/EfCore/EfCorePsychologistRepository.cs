using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Data.Concrete.EfCore.Context;
using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Concrete.EfCore
{
    public class EfCorePsychologistRepository : EfCoreGenericRepository<Psychologist>, IPsychologistRepository
    {
        public EfCorePsychologistRepository(ConsultancyAppContext _appContext) : base(_appContext)
        {

        }
        ConsultancyAppContext AppContext
        {
            get { return _dbContext as ConsultancyAppContext; }
        }
        public async Task<List<Psychologist>> GetAllPsychologistDataAsync(bool ApprovedStatus=false)
        {
            var psychologist =  AppContext
                .Psychologist.Include(p => p.PsychologistCategory).ThenInclude(pc => pc.Category)
                .Include(p => p.Image).AsQueryable();
            if(ApprovedStatus)
            {
                psychologist = psychologist.
                Where(p => p.IsApproved == ApprovedStatus);
            }
            return await psychologist.ToListAsync(); 
        }
        public async Task<Psychologist> GetPsychologistFullDataAsync(int id)
        {
            var psychologist = await AppContext
                .Psychologist.Where(p=>p.Id== id)
                .Include(p=>p.PsychologistDescription)
                .Include(p=>p.PsychologistCategory).ThenInclude(pc=>pc.Category)
                .Include(p=>p.PsychologistCustomer).ThenInclude(pc=>pc.Customer)
                .Include(pi=>pi.Image).FirstOrDefaultAsync();
            return psychologist;
        }
        public async Task<List<Psychologist>> GetPsychologistsByCategoriesAsync(int categoryId)
        {
            List<Psychologist> psychologists = await AppContext
                .Psychologist
                .Include(p=>p.PsychologistDescription).Include(i=>i.Image)
                .Include(p => p.PsychologistCategory).ThenInclude(pc => pc.Category).Where(ci => ci.PsychologistCategory.Any(x=>x.CategoryId == categoryId)).ToListAsync();
            return psychologists;
        }

        public  async Task<List<Psychologist>> GetPsychologistsByCustomerAsync(int customerId)
        {
            List<Psychologist> psychologist = await AppContext
                .Psychologist
                .Include(p=>p.PsychologistCategory).ThenInclude(pc=>pc.Category)
                .Include(p => p.PsychologistCustomer).ThenInclude(p => p.Customer)
                .Where(c => c.PsychologistCustomer.Any(x => x.CustomerId == customerId)).ToListAsync();
            return psychologist;
        }
        public async Task UpdatePsychologist(Psychologist psychologist, int[] SelectedCategories, PsychologistDescription psychologistDescription,int[] psychologistCustomers)
        {
            Psychologist updatePsychologist = await AppContext.Psychologist.Include(P => P.PsychologistCategory).Include(p => p.PsychologistDescription).FirstOrDefaultAsync(b => b.Id == psychologist.Id);
                //.Include(p => p.PsychologistCustomer)
            #region Psychologist atamları.
            updatePsychologist.Name = psychologist.Name;
            updatePsychologist.CreatedDate = psychologist.CreatedDate;
            updatePsychologist.ModifiedDate = psychologist.ModifiedDate;
            updatePsychologist.IsApproved = psychologist.IsApproved;
            updatePsychologist.Price = psychologist.Price;
            updatePsychologist.Url = psychologist.Url;
            updatePsychologist.Gender = psychologist.Gender;
            updatePsychologist.Name = psychologist.Name;
            updatePsychologist.Image = psychologist.Image;
            #endregion
            #region PsychologistDescription atamaları
            updatePsychologist.PsychologistDescription.Id = psychologistDescription.Id;
            updatePsychologist.PsychologistDescription.GraduationYear = psychologistDescription.GraduationYear;
            updatePsychologist.PsychologistDescription.Education = psychologistDescription.Education;
            updatePsychologist.PsychologistDescription.Experience = psychologistDescription.Experience;
            updatePsychologist.PsychologistDescription.About = psychologistDescription.About;
            #endregion
            #region Seçilen Kategory Ataması
            updatePsychologist.PsychologistCategory = SelectedCategories.Select(bc => new PsychologistCategory
            {
                PsychologistId = updatePsychologist.Id,
                CategoryId = bc,
            }).ToList();
            #endregion
            #region PsychologistCustomer Düzenlenmesi
            //MANTIĞINI KURAMADIM DAHA SONRA DÖNÜLECEK.
            //updatePsychologist.PsychologistCustomer=psychologistCustomers.Where(pc=>pc==)
            #endregion
            AppContext.Update(updatePsychologist);  
            await AppContext.SaveChangesAsync();
        }
        public  async Task CreatePsychologist(Psychologist psychologist, int[] SelectedCategories, Image image, PsychologistDescription psychologistDescription)
        {
            await AppContext.Psychologist.AddAsync(psychologist);
            await AppContext.SaveChangesAsync();
            //Bilgisi doldurulan psikoloğun bilgileri veri tabanına eklendi.s
            List<PsychologistCategory> psychologistCategories = new List<PsychologistCategory>();
            foreach (var categoryId in SelectedCategories)
            {
                psychologistCategories.Add(new PsychologistCategory
                {
                    CategoryId = categoryId,
                    PsychologistId = psychologist.Id
                });
                AppContext.PsychologistCategory.AddRange(psychologistCategories);
            }
            image.PsychologistId = psychologist.Id;
            await AppContext.Images.AddAsync(image);

            psychologistDescription.PsychologistId=psychologist.Id;

            await AppContext.PsychologistDescription.AddAsync(psychologistDescription);
            await AppContext.SaveChangesAsync();
        }

        public async Task<Psychologist> GetPsychologistFullDataByUserId(string userId)
        {
            var psychologist=await AppContext.Psychologist.Where(p=>p.userId==userId).Include(p => p.PsychologistDescription)
                .Include(p => p.PsychologistCategory).ThenInclude(pc => pc.Category)
                .Include(p => p.PsychologistCustomer).ThenInclude(pc => pc.Customer)
                .Include(pi => pi.Image).FirstOrDefaultAsync();
            return psychologist;
        }
    }
}
  