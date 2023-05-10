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
    public class EfCoreRequestRepository:EfCoreGenericRepository<Request>,IRequestRepository
    {
        public EfCoreRequestRepository(ConsultancyAppContext _appContext) : base(_appContext)
        {

        }
        ConsultancyAppContext AppContext
        {
            get { return _dbContext as ConsultancyAppContext; }
        }

        public async Task CreateRequest(Request request, int[] SelectedCategories, Image image)
        {
            await AppContext.Request.AddAsync(request);
            await AppContext.SaveChangesAsync();
            List<RequestCategory> requestCategory = new List<RequestCategory>();
            foreach (var categoryId in SelectedCategories)
            {
                requestCategory.Add(new RequestCategory
                {
                    CategoryId = categoryId,
                    RequestId = request.Id
                });
                AppContext.RequestCategory.AddRange(requestCategory);

            }
            image.RequestId = request.Id;
            await AppContext.Images.AddAsync(image);

        }

        public async Task<List<Request>> GetAllRequestFullDataAsync()
        {
            var request = await AppContext.Request.Where(r => r.IsApproved==false).Include(c=>c.RequestCategories).ThenInclude(c=>c.Category).Include(i=>i.Image). ToListAsync();
            return request;
        }
        public async Task<Request> GetRequestFullDataAsync(int id)
        {
            var request = await AppContext.Request.Where(r => r.Id == id).Include(r => r.RequestCategories).ThenInclude(c => c.Category).Include(i => i.Image).FirstOrDefaultAsync();
            return request;
        }
    }
}
