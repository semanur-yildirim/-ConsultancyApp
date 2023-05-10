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
    public class RequestCategoryConfig : IEntityTypeConfiguration<RequestCategory>
    {
        public void Configure(EntityTypeBuilder<RequestCategory> builder)
        {
            builder.HasKey(pc => new { pc.RequestId, pc.CategoryId });

            builder.HasOne(x => x.Request).WithMany(x => x.RequestCategories).HasForeignKey(x => x.RequestId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category).WithMany(x => x.RequestCategories).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new RequestCategory { RequestId = 1, CategoryId = 1 }
                );
        }
    }
}
