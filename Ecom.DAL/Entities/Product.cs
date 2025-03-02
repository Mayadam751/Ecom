﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
       
        public ICollection<OrderedProduct> OrderedProduct { get; set; }
    }
}
