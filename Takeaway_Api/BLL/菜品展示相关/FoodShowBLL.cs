using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using SDK;

namespace BLL
{
    public class FoodShowBLL
    {
        public show Show(int currPage, string Name, int TypeId)
        {
            return BaseDAL<FoodShowDAL>.Instance.Show(currPage,Name,TypeId);
        }
    }
}
