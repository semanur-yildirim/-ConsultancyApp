﻿using ConsultancyApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class Category:IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public string  Name { get; set; }   
        public CategoryDescription CategoryDescription { get; set; }
        public List<PsychologistCategory> PsychologitstCategry { get; set; }
        public List<RequestCategory> RequestCategories { get; set; }

    }
}
