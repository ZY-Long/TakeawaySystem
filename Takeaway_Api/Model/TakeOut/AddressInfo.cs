using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户地址表
    /// </summary>
   public class AddressInfo
    {
        //地址Id
        public int Id { get; set; }
        //省Id
        public int ProvinceId { get; set; }
        //市Id
        public int CityId { get; set; }
        //区Id
        public int AreaId { get; set; }
        //详细地址
        public string Content { get; set; }
    }
}
