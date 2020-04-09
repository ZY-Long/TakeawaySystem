using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using SDK;
namespace BLL
{
   public class TakeBLL
    {
        /// <summary>
        /// 添加购物车详情
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public int AddCartDetails(int minefid, int userId, int count)
        {
            return BaseDAL<TakeDAL>.Instance.AddCartDetails(minefid, userId, count);
        }
        /// <summary>
        /// 删除购物车
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteCart(int id)
        {
            return BaseDAL<TakeDAL>.Instance.DeleteCart(id);
        }
        /// <summary>
        /// 显示商品详情
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="menuid"></param>
        /// <returns></returns>
        public MenuDetail GetMenuDetail( int menuid)
        {
            return BaseDAL<TakeDAL>.Instance.GetMenuDetail(menuid);
        }
        /// <summary>
        /// 显示口味下拉框
        /// </summary>
        /// <returns></returns>

        public List<TasteInfo> GetTakeInfos()
        {
            return BaseDAL<TakeDAL>.Instance.GetTakeInfos();
        }
        /// <summary>
        /// 显示购物车
        /// </summary>
        /// <returns></returns>
        public List<CartInfos> GetCartInfos(int userid)
        {
            return BaseDAL<TakeDAL>.Instance.GetCartInfos(userid);
        }
        //public int AddCart(CartInfo cart)
        //{
        //    return BaseDAL<TakeDAL>.Instance.AddCart(cart);
        //}
        /*添加购物车*/

        /// <summary>
        /// 添加购物车
        /// </summary>
        /// <returns></returns>
        public int CartTran(int minefid, int userId, int count)
        {
            return BaseDAL<TakeDAL>.Instance.CartTran(minefid,userId,count);
        }


    }
}
