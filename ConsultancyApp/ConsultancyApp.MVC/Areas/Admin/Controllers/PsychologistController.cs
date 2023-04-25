
using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.MVC.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConsultancyApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PsychologistController : Controller
    {
        private readonly IPsychologistService _psychologistService;

        public PsychologistController(IPsychologistService psychologistService)
        {
            _psychologistService = psychologistService;
        }

        public async Task<IActionResult> Index()
        {
            List<Psychologist> psychologistList = await _psychologistService.GetAllPsychologistDataAsync();
            List<PsychologistViewModel> psychologist = new List<PsychologistViewModel>();
            foreach (var p in psychologistList)
            {
                psychologist.Add(new PsychologistViewModel
                {
                    Id=p.Id,
                    Name=p.Name,
                    Categories=p.PsychologistCategory.Select(c=> new CategoryViewModel{
                        Id=c.CategoryId,
                        Name=c.Category.Name,
                        IsApproved=c.Category.IsApproved,
                        Url=c.Category.Url,
                    }).ToList()
                });
            }
            return View(psychologist);
        }
    }
}
