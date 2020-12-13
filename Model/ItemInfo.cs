using System;

namespace PetShop.Model
{
	/// <summary>
	/// Business entity used to model an item.
	/// </summary>
	[Serializable]
	public class ItemInfo{



		// Properties
		public string Id { get; set; }

		public string Name { get; set; }

        public string ProductName { get; set; }

        public string ProductDesc { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
