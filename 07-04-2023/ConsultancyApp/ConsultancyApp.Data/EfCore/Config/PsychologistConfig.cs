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
                new Psychologist { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Name = "Selvi",  Price = 450, Url = "Selvi-psikolog", Gender="Kadın",userId= "8da007be-c50b-4973-aa45-224b7358hkn15" },
                );


        }
    }
}
