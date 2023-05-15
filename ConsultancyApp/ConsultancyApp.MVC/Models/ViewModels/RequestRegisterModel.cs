﻿using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.Entity.Concrete.Identity;
using ConsultancyApp.MVC.Areas.Admin.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsultancyApp.MVC.Models.ViewModels
{
    public class RequestRegisterModel
    {
        public int Id { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        [DisplayName(" Ücret Alanı")]
        [Required(ErrorMessage = "Ücret alanı boş bırakılamaz")]
        public decimal? Price { get; set; }

        [DisplayName(" Cinsiyet Alanı")]
        [Required(ErrorMessage = "Cinsiyet alanı boş bırakılamaz")]
        public string Gender { get; set; }
        public List<SelectListItem> GenderSelectList { get; set; }
        [DisplayName("  Profil Fotoğrafı")]
        [Required(ErrorMessage = "Profil Fotoğrafı boş bırakılamaz")]
        public IFormFile Image { get; set; }

        #region Description
        [DisplayName("Mezuniyet Yılı")]
        [Required(ErrorMessage = "Mezuniyet alanı boş bırakılamaz")]
        public DateTime GraduationYear { get; set; }

        [DisplayName("Deneyim")]
        [Required(ErrorMessage = "Deneyim alanı boş bırakılamaz")]
        public string Experience { get; set; }
        [DisplayName("Eğitim")]
        [Required(ErrorMessage = "Eğitim alanı boş bırakılamaz")]
        public string Education { get; set; }

        [DisplayName("Hakkında")]
        [Required(ErrorMessage = "Hakkında alanı boş bırakılamaz")]
        public string About { get; set; }
        #endregion
        [Required(ErrorMessage = "En az bir kategori seçilmelidir")]
        [DisplayName(" Kategoriler ")]
        public int[] SelectedCategories { get; set; }

        public List<Category> Categories { get; set; }
        public UserRegisterModel User { get; set; }
        public EnumType Type { get; set; } = EnumType.Psychologist;
    }
}