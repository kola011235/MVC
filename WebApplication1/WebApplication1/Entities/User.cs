﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3_DB.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateIfBirth { get; set; }
        public int Age { get; set; }
    }
}
