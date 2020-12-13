using System;
using System.Data;
using System.Data.SqlClient;
using PetShop.Model;
using PetShop.Data.SqlServer.Models;
using PetShop.IDAL;

namespace PetShop.SQLServerDAL {
	/// <summary>
	/// Summary description for InventoryDALC.
	/// </summary>
	public class InventoryDAO : IInventoryDO{
        PetShopDbContext db = new PetShopDbContext();
        
		/// <summary>
		/// Function to get the current quantity in stock
		/// </summary>
		/// <param name="ItemId">Unique identifier for an item</param>
		/// <returns>Current Qty in Stock</returns>
		public int CurrentQtyInStock(string ItemId){
            return db.Inventories.Find(ItemId).Qty;
		}

        /// <summary>
        /// Function to update inventory based on purchased items
        /// Internally the function uses a batch query so the command is only sent to the database once
        /// </summary>
        /// <param name="items">Array of items purchased</param>
        public void TakeStock(LineItemInfo[] items)
        {
            foreach (LineItemInfo item in items)
            {
                db.Inventories.Find(item.ItemId).Qty -= item.Quantity;
            }
            db.SaveChanges();
        }
	}
}
