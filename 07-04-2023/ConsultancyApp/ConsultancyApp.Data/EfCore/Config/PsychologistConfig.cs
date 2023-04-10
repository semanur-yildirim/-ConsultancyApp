using Microsoft.EntityFrameworkCore;
using ConsultancyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultancyApp.Entity.Concrete.Identity;
using System.Reflection;
using System.Xml.Linq;

namespace ConsultancyApp.Data.EfCore.Config
{
    internal class PsychologistConfig : IEntityTypeConfiguration<Psychologist>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Psychologist> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Gender).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.userId).IsRequired();
            builder.HasData(
                new Psychologist { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Selvi",  Price = 450, Url = "Selvi-psikolog", Gender="Kadın",userId="blablabla" },
                new Psychologist { Id = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Maxwell", Price = 500, Url = "Maxwell-psikolog", Gender = "Erkek", userId = "abcde1234" },
                new Psychologist { Id = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = false, Name = "Sophie", Price = 400, Url = "Sophie-psikolog", Gender = "Kadın", userId = "qwerty5678" },
                new Psychologist { Id = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Miles", Price = 550, Url = "Miles-psikolog", Gender = "Erkek", userId = "xoxoxo2468" },
                new Psychologist { Id = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = false, Name = "Lena", Price = 350, Url = "Lena-psikolog", Gender = "Kadın", userId = "1234567890" },
                new Psychologist { Id = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Ethan", Price = 600, Url = "Ethan-psikolog", Gender = "Erkek", userId = "asdfgh1234" },
                new Psychologist { Id = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = false, Name = "Grace", Price = 425, Url = "Grace-psikolog", Gender = "Kadın", userId = "zxcvbn5678" },
                new Psychologist { Id = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Oliver", Price = 575, Url = "Oliver-psikolog", Gender = "Erkek", userId = "qweasd2468" },
                new Psychologist { Id = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = false, Name = "Emma", Price = 375, Url = "Emma-psikolog", Gender = "Kadın", userId = "zxcasd1234" },
                new Psychologist { Id = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Jacob", Price = 525, Url = "Jacob-psikolog", Gender = "Erkek", userId = "qwezxc5678" }
                );


        }
    }
}
