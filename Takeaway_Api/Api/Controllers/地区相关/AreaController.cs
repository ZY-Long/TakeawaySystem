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
    /// <summary>
    /// 地区相关控制器
    /// </summary>
    public class AreaController : ApiController
    {
        /// <summary>
        /// 获取地区集合
        /// </summary>
        /// <param name="cityRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public AreaResponse GetArealnfos(AreaRequest areaRequest)
        {

            AreaResponse response = new AreaResponse();
            var infos = BaseBLL<AreaBLL>.Instance.GetArealnfos();
            response.Arealnfos = new List<AreaDto>();
            foreach (var item in infos)
            {
                response.Arealnfos.Add(new AreaDto() {Id=item.Id,Name=item.Name });
            }
            response.State = response.Arealnfos.Count > 0 ? true : false;
            return response;
        }
    }
}
