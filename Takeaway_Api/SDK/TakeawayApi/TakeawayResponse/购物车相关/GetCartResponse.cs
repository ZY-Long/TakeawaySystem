﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace SDK
{
   public class GetCartResponse:BaseResponse
    {
        public List<CartInfos> GetCart { get; set; }
    }
}
