﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    /// <summary>
    /// 地区相关DAL
    /// </summary>
    public class AreaDAL
    {
        DBHelper DBHelper = new DBHelper();

        /// <summary>
        /// 获取城市集合,用作下拉
        /// </summary>
        /// <returns></returns>
        public List<Arealnfo> GetArealnfos()
        {
            List<Arealnfo> infos = DBHelper.GetToList<Arealnfo>("SELECT * FROM dbo.Arealnfo WHERE CityId= 1");
                //OrmDBHelper.GetToList<Arealnfo>("SELECT * FROM dbo.Arealnfo WHERE CityId= 1");
            return infos;
        }
    }
}
