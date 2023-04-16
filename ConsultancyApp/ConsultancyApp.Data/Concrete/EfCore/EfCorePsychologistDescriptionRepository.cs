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
    public class EfCorePsychologistDescriptionRepository : EfCoreGenericRepository<PsychologistDescription>, IPsychologistDescriptionRepository
    {
        public EfCorePsychologistDescriptionRepository(DbContext _appContext) : base(_appContext)
        {
        }
        ConsultancyAppContext AppContext
        {
            get { return _dbContext as ConsultancyAppContext; }
        }

        public async Task<PsychologistDescription> GetPsychologistDescriptionByPsychologistAsync(int psychologistId)
        {
            return await AppContext.PsychologistDescription.Where(pd => pd.PsychologistId == psychologistId).FirstOrDefaultAsync();

        }
    }
}
