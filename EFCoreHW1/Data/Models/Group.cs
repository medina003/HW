﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreHW1.Data.Models
{
    public  class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
