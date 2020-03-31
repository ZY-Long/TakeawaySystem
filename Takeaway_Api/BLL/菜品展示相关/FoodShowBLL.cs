using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SDK;
using Model;

namespace BLL
{
    public class FoodShowBLL
    {
        public List<MenuInfo> Show(int currPage,  int TypeId, string Name)
        {
            return BaseDAL<FoodShowDAL>.Instance.Show(currPage,TypeId,Name);
        }
    }
}
