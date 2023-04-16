using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Abstract
{
    public interface IImageRepository:IGenericRepository<Image>
    {
        Task<Image> GetImageByPsychologist(int psychologitId);
    }
}
