﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiVueJs.Model
{
    public class Item
    {
        public int ID { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal? Value { get; set; }

        
    }
}
