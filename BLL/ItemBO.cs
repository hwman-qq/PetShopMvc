using System.Collections;

//References to PetShop specific libraries
//PetShop busines entity library
using PetShop.Model;
//PetShop DAL interfaces
using PetShop.IDAL;
using System.Collections.Generic;

namespace PetShop.BLL {

	/// <summary>
	/// A business component to manage product items
	/// </summary>
	public class ItemBO {

        // Get an instance of the Item DAL using the DALFactory
        public IItemDO dal = DALFactory.getItemDAL();

        /// <summary>
		/// A method to list items by productId
		/// Every item is associated with a parent product
		/// </summary>
		/// <param name="productId">The productId to search by</param>
		/// <param name="productName">Name of the product associated with the product</param>
		/// <returns>An interface to an arraylist</returns>
		public IList<ItemInfo> GetItemsByProduct(string productId) {

			// Validate input
			if (productId.Trim() == string.Empty)
				return null;

			// Use the dal to search by productId
			return dal.GetItemsByProduct(productId);
		}

		/// <summary>
		/// Search for an item given it's unique identifier
		/// </summary>
		/// <param name="itemId">Unique identifier for an item</param>
		/// <returns>An Item business entity</returns>
		public ItemInfo GetItem(string itemId) {

			// Validate input
			if (itemId.Trim() == string.Empty)
				return null;

			// Use the dal to search by ItemId
			return dal.GetItem(itemId);
		}
	}
}