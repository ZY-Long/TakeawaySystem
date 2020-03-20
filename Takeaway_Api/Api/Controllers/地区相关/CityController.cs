using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Model;
using SDK;

namespace Api.Controllers
{
    public class CityController : ApiController
    {
        [HttpPost]
        public CityResponse GetCityInfos()
        {
            CityResponse response = new CityResponse();
            response.CityInfos = BaseBLL<CityBLL>.Instance.GetCityInfos();
            return response;
        }
    }
}
