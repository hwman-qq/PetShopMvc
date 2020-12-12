using System;

namespace PetShop.Model {

	/// <summary>
	/// Business entity used to model an order
	/// </summary>
	[Serializable]
	public class OrderInfo {

		// Internal member variables
		private int _orderId;
		private DateTime _date;
		private string _userId;
		private CreditCardInfo _creditCard;
		private AddressInfo _billingAddress;
		private AddressInfo _shippingAddress;
		private decimal _orderTotal;
		private LineItemInfo[] _lineItems;	

		/// <summary>
		/// Default constructor
		/// This is required by web services serialization mechanism
		/// </summary>
		public OrderInfo(){}

		/// <summary>
		/// Constructor with specified initial values
		/// </summary>
		/// <param name="orderId">Unique identifier</param>
		/// <param name="date">Order date</param>
		/// <param name="userId">User placing order</param>
		/// <param name="creditCard">Credit card used for order</param>
		/// <param name="billing">Billing address for the order</param>
		/// <param name="shipping">Shipping address for the order</param>
		/// <param name="total">Order total value</param>
		public OrderInfo(int orderId, DateTime date, string userId, CreditCardInfo creditCard, AddressInfo billing, AddressInfo shipping, decimal total){
			this._orderId = orderId;
			this._date = date;
			this._userId = userId;
			this._creditCard = creditCard;
			this._billingAddress = billing;
			this._shippingAddress = shipping;
			this._orderTotal = total;
		}

		// Properties
		public int OrderId {
			get { return _orderId; }
			set { _orderId = value; }
		}

		public DateTime Date {
			get { return _date; }
			set { _date = value; }
		}

		public string UserId {
			get { return _userId; }
			set { _userId = value; }
		}

		public CreditCardInfo CreditCard {
			get { return _creditCard; }
			set { _creditCard = value; }
		}

		public AddressInfo BillingAddress {
			get { return _billingAddress; }
			set { _billingAddress = value; }
		}

		public AddressInfo ShippingAddress {
			get { return _shippingAddress; }
			set { _shippingAddress = value; }
		}

		public decimal OrderTotal {
			get { return _orderTotal; }
			set { _orderTotal = value; }
		}

		public LineItemInfo[] LineItems {
			get { return _lineItems; }
			set { _lineItems = value; }
		}
	}
}