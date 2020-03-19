using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BLL
{
   public class TakeBLL
    {
        TakeDAL dal = new TakeDAL();
        public List<TasteInfo> ShowTasteInfo()
        {
            return BaseDAL<TakeDAL>.Instance.ShowTasteInfo();
        }
    }
}
