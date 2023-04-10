using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsultancyApp.Data.EfCore.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {


        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasData(
                new Category { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Bireysel Terapi", Url = "bireysel-terapi" },
                new Category { Id = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Çift Terapisi", Url = "cift-terapisi" },
                new Category { Id = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Aile Terapisi", Url = "aile-terapisi" },
                new Category { Id = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = false, Name = "Çocuk Terapisi", Url = "cocuk-terapisi" },
                new Category { Id = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Ergen Terapisi", Url = "ergen-terapisi" },
                new Category { Id = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Bağımlılık Terapisi", Url = "bagimlilik-terapisi" },
                new Category { Id = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = false, Name = "Psikolojik Danışmanlık", Url = "psikolojik-danismanlik" },
                new Category { Id = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Stres Yönetimi", Url = "stres-yonetimi" },
                new Category { Id = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Depresyon Terapisi", Url = "depresyon-terapisi" },
                new Category { Id = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Anksiyete Terapisi", Url = "anksiyete-terapisi" }
                 );

        }
    }
}
