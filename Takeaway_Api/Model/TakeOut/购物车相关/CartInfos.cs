﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class CartInfos
    {
        public string Img { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal ToPrice { get; set; }
    }
}
