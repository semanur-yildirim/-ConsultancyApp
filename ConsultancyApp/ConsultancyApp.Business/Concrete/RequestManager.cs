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
    public class RequestManager:IRequestService
    {
        private IRequestRepository _requestRepository;

        public RequestManager(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task CreateRequest(Request request, int[] SelectedCategories, Image image)
        {
            await _requestRepository.CreateRequest(request, SelectedCategories, image);
        }

            public  void Delete(Request request)
        {
           _requestRepository.Delete(request);
        }

        public async Task<List<Request>> GetAllRequestFullDataAsync()
        {
            return await _requestRepository.GetAllRequestFullDataAsync();
        }

        public async Task<Request> GetRequestFullDataAsync(int id)
        {
            return await _requestRepository.GetRequestFullDataAsync(id);
        }
    }
}
