using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Concrete.EfCore.Config
{
    public class PsychologistCategoryConfig : IEntityTypeConfiguration<PsychologistCategory>
    {
        public void Configure(EntityTypeBuilder<PsychologistCategory> builder)
        {
            builder.HasKey(pc => new { pc.PsychologistId, pc.CategoryId });

            builder.HasOne(x=>x.Psychologist).WithMany(x=>x.PsychologistCategory).HasForeignKey(x=>x.PsychologistId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Category).WithMany(x => x.PsychologitstCategry).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new PsychologistCategory { PsychologistId = 1, CategoryId = 1 },
                new PsychologistCategory { PsychologistId = 1, CategoryId = 2 },
                new PsychologistCategory { PsychologistId = 1, CategoryId = 3 },

                new PsychologistCategory { PsychologistId = 2, CategoryId = 4 },
                new PsychologistCategory { PsychologistId = 2, CategoryId = 5 },
                new PsychologistCategory { PsychologistId = 2, CategoryId = 6 },

                new PsychologistCategory { PsychologistId = 3, CategoryId = 7 },
                new PsychologistCategory { PsychologistId = 3, CategoryId = 8 },
                new PsychologistCategory { PsychologistId = 3, CategoryId = 1 },

                new PsychologistCategory { PsychologistId = 4, CategoryId = 2 },
                new PsychologistCategory { PsychologistId = 4, CategoryId = 3 },
                new PsychologistCategory { PsychologistId = 4, CategoryId = 4 },

                new PsychologistCategory { PsychologistId = 5, CategoryId = 1 },
                new PsychologistCategory { PsychologistId = 5, CategoryId = 2 },
                new PsychologistCategory { PsychologistId = 5, CategoryId = 5 },
                new PsychologistCategory { PsychologistId = 5, CategoryId = 4 },

                new PsychologistCategory { PsychologistId = 6, CategoryId = 5 },
                new PsychologistCategory { PsychologistId = 6, CategoryId = 6 },

                new PsychologistCategory { PsychologistId = 7, CategoryId = 7 },
                new PsychologistCategory { PsychologistId = 7, CategoryId = 8 },
                new PsychologistCategory { PsychologistId = 7, CategoryId = 5 },

                new PsychologistCategory { PsychologistId = 8, CategoryId = 6 },
                new PsychologistCategory { PsychologistId = 8, CategoryId = 7 },

                new PsychologistCategory { PsychologistId = 9, CategoryId = 8 },
                new PsychologistCategory { PsychologistId = 9, CategoryId = 5 },
                new PsychologistCategory { PsychologistId = 9, CategoryId = 4 },

                new PsychologistCategory { PsychologistId = 10, CategoryId = 6 }
          );
        }
    }
}
