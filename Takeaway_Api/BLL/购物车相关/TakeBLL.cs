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
        
        public List<TasteInfo> ShowTasteInfo()
        {
            return BaseDAL<TakeDAL>.Instance.ShowTasteInfo();
        }
        public List<CartDetails> ShowCartDetails()
        {
            return BaseBLL<TakeDAL>.Instance.ShowCartDetails();
        }
        //public int AddCart(CartInfo cart)
        //{
        //    return BaseDAL<TakeDAL>.Instance.AddCart(cart);
        //}
        /*添加购物车*/
       
    }
}
