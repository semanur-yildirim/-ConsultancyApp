using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsultancyApp.Data.Concrete.EfCore.Config
{
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.Property(x => x.Url).IsRequired().HasMaxLength(500);
            builder.HasOne(p => p.Psychologist).WithOne(p => p.Image).HasForeignKey<Image>(t => t.PsychologistId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Request).WithOne(p => p.Image).HasForeignKey<Image>(t => t.RequestId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
               new Image { Id = 11, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Url = "r-1.jpg", RequestId = 1 },
                new Image { Id = 1, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Url = "k-1.jpg", PsychologistId = 1 },
                new Image { Id = 2, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Url = "k-2.jpg", PsychologistId = 2 },
                 new Image { Id = 3, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Url = "k-3.jpg", PsychologistId = 3 },
                 new Image { Id = 4, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Url = "k-4.jpg", PsychologistId = 4 },
                 new Image { Id = 5, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Url = "k-5.jpg", PsychologistId = 5 },
                   new Image { Id = 6, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Url = "e-1.jpg", PsychologistId = 6 },
                 new Image { Id = 7, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Url = "e-2.jpg", PsychologistId = 7 },
                   new Image { Id = 8, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Url = "e-3.jpg", PsychologistId = 8 },
                 new Image { Id = 9, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Url = "e-4.jpg", PsychologistId = 9 },
                  new Image { Id = 10, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, IsApproved = true, Url = "e-5.jpg", PsychologistId = 10 }
                );
        }
    }
}
