using ConsultancyApp.Entity.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace ConsultancyApp.MVC.Areas.Admin.Models.ViewModels
{
    public class PsychologistViewModel
    {
        public int Id { get; set; }
        
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }  
        public Image Image { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
    }
}
