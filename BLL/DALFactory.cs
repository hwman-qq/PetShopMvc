using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PetShop.IDAL;

namespace PetShop.BLL
{
    /*
     * 数据访问对象的工厂类
     * 这是BLL层唯一直接引用数据访问层的一个类。
     * 需要更换数据访问层时，只需要直接修改本类中的方法即可，将变动范围集中限制在一个类内部
     */
    class DALFactory
    {
        public static string DAL_TYPE = "SQLServerDAL";

        public static IAccountDO getAccountDAL()
        {
            return new PetShop.SQLServerDAL.Account();
        }

        public static IInventoryDO getInventoryDAL()
        {
            return new PetShop.SQLServerDAL.Inventory();
        }

        public static IItemDO getItemDAL()
        {
            return new PetShop.SQLServerDAL.Item();
        }

        public static IOrderDO getOrderDAL()
        {
            return new PetShop.SQLServerDAL.Order();
        }

        public static IProductDO getProductDAL()
        {
            return new PetShop.SQLServerDAL.Product();
        }

        public static IProfileDO getProfileDAL()
        {
            return new PetShop.SQLServerDAL.Profile();
        }
    }
}
