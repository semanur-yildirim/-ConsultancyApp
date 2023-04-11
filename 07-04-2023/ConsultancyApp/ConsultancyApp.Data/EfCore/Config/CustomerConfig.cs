using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.EfCore.Config
{
    public class CustomerConfig:IEntityTypeConfiguration<Customer>
    {
       

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.userId).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            //builder.HasData(

            //    new Customer { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Ahmet", Url = "ahmet-hasta", userId = "kullanıcı1" ,Address="Armağan evler mahallesi 23 Nisan Caddesi no:37 Daire:4",PsychologistId=1},
            //    new Customer { Id = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Selin", Url = "selin-hasta", userId = "kullanıcı2", Address = "Güzelbahçe mahallesi Kumsal sokak no:13", PsychologistId = 2 },
            //    new Customer { Id = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Mehmet", Url = "mehmet-hasta", userId = "kullanıcı3", Address = "Karşıyaka mahallesi Yalı Caddesi no:27 Daire:5", PsychologistId = 3 }

            //                    );
        }
    }
}
