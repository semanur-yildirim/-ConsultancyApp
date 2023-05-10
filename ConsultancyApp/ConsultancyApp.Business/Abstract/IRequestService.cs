using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Business.Abstract
{
    public interface IRequestService
    {
        Task<List<Request>> GetAllRequestFullDataAsync();
        Task<Request> GetRequestFullDataAsync(int id);
        Task CreateRequest(Request request, int[] SelectedCategories, Image image
            );
        void Delete(Request psychologist);
    }
}
