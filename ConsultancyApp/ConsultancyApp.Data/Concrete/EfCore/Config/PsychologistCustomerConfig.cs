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
    public class PsychologistCustomerConfig : IEntityTypeConfiguration<PsychologistCustomer>

    {
        public void Configure(EntityTypeBuilder<PsychologistCustomer> builder)
        {
            builder.HasKey(pc => new { pc.PsychologistId, pc.CustomerId });
            builder.HasData(
                new PsychologistCustomer { PsychologistId = 1, CustomerId = 1 },
                new PsychologistCustomer { PsychologistId = 2, CustomerId = 2 },
                new PsychologistCustomer { PsychologistId = 3, CustomerId = 3 },
                new PsychologistCustomer { PsychologistId = 4, CustomerId = 1 },
                new PsychologistCustomer { PsychologistId = 5, CustomerId = 2 },
                new PsychologistCustomer { PsychologistId = 6, CustomerId = 2 }
                );

        }
    }
}
