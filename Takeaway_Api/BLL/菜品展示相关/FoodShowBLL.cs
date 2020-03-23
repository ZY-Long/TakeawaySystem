using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.菜品展示相关
{
    public class FoodShowBLL
    {
        public SqlDataReader Show(int currPage, string Name, int TypeId)
        {
            return BaseDAL<FoodShowDAL>.Instance.Show(currPage,Name,TypeId);
        }
    }
}
