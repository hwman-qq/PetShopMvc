using PetShop.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PetShop.IDAL{
	
	/// <summary>
	/// Interface for the Product DAL
	/// </summary>
	public interface IProductDO{
	
		/// <summary>
		/// Method to search products by category name
		/// </summary>
		/// <param name="category">Name of the category to search by</param>
		/// <returns>Interface to an arraylist of search results</returns>
		IList<ProductInfo> GetProductsByCategory(string category);


		/// <summary>
		/// Method to search products by a set of keyword
		/// </summary>
		/// <param name="keywords">An array of keywords to search by</param>
		/// <returns>Interface to an arraylist of search results</returns>
		IList<ProductInfo> GetProductsBySearch(string[] keywords);
	}
}
