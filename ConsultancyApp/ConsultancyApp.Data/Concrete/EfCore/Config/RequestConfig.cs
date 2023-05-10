using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.Entity.Concrete.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Concrete.EfCore.Config
{
    public class RequestConfig : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasData(
                    new Request {Id=1,
                        FirstName = "Sevil",
                        LastName = "Kara",
                        UserName = "sevil",
                        Email = "sevil@gmail.com", 
                        DateOfBirth = new DateTime(1978, 5, 2), CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        IsApproved = false,
                        Name = "Seil Kara",
                        Price = 450,
                        Url = "Sevil-Kara",
                        Gender = "Kadın",
                        GraduationYear = new DateTime(2000, 12, 5),
                        Education = "İstanbul Üniversitesi Psikoloji",
                        Experience = "Online ve Yüz yüze Terapi",
                        About = "Sosyal Terapist, Bağımlılık Terapisti, Psikodrama Yöneticisi, Organizasyon Geliştirici İzmir Üniversitesi bölümünü tamamlayıp, ardından Almanya’da Sağlık Managment Yüksek Lisans Master egitimini  Magdeburg-Stendal Yüksekokulunda tamamlamıştır. Almanya’da psikososyal alanda 1982 yılından itibaren mesleki calışmasına paralel, 2013 tarihine kadar Sosyalterapi, Bagimlilik terapisti, Psikodrama Grup Yöneticisi, Organizasyon Geliştirici ve Choac  eğitimlerini aldı.",
                        Password="Qwe123."
                    }
                );
        }
    }
}
