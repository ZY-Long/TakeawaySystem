using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 用户地址相关
    /// </summary>
    public class UserAddress
    {
        /// <summary>
        /// 地址Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 地区名称
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 详细地址
        /// </summary>
        public string Content { get; set; }

    }
}
