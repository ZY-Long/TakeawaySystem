﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK;
namespace BLL
{
   public class ShowTakeBLL
    {
        public TakeResponse GetTake(TakeRequest request)
        {
            return ApiRequestHelper.Post<TakeRequest, TakeResponse>(request);
        }
    }
}
