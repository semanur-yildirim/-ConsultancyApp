﻿using ConsultancyApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Entity.Concrete
{
    public class Psychologist : IBaseEntity
    {
        public int Id { get ; set ; }
        public DateTime CreatedDate { get; set ; }
        public DateTime ModifiedDate { get; set ; }
        public bool IsApproved { get; set ; }
        public string Url { get ; set ; }
    }
}
