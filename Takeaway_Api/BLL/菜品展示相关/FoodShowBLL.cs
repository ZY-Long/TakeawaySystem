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
        public show Show(int currPage,  int TypeId, string Name)
        {
            return BaseDAL<FoodShowDAL>.Instance.Show(currPage, TypeId, Name);
        }
    }
}
