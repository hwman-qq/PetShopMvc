namespace PetShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            LineItems = new HashSet<LineItem>();
            OrderStatus = new HashSet<OrderStatu>();
        }

        public int OrderId { get; set; }

        [Required]
        [StringLength(20)]
        public string UserId { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(80)]
        public string ShipAddr1 { get; set; }

        [StringLength(80)]
        public string ShipAddr2 { get; set; }

        [Required]
        [StringLength(80)]
        public string ShipCity { get; set; }

        [Required]
        [StringLength(80)]
        public string ShipState { get; set; }

        [Required]
        [StringLength(20)]
        public string ShipZip { get; set; }

        [Required]
        [StringLength(20)]
        public string ShipCountry { get; set; }

        [Required]
        [StringLength(80)]
        public string BillAddr1 { get; set; }

        [StringLength(80)]
        public string BillAddr2 { get; set; }

        [Required]
        [StringLength(80)]
        public string BillCity { get; set; }

        [Required]
        [StringLength(80)]
        public string BillState { get; set; }

        [Required]
        [StringLength(20)]
        public string BillZip { get; set; }

        [Required]
        [StringLength(20)]
        public string BillCountry { get; set; }

        [Required]
        [StringLength(80)]
        public string Courier { get; set; }

        public decimal TotalPrice { get; set; }

        [Required]
        [StringLength(80)]
        public string BillToFirstName { get; set; }

        [Required]
        [StringLength(80)]
        public string BillToLastName { get; set; }

        [Required]
        [StringLength(80)]
        public string ShipToFirstName { get; set; }

        [Required]
        [StringLength(80)]
        public string ShipToLastName { get; set; }

        [Required]
        [StringLength(20)]
        public string CreditCard { get; set; }

        [Required]
        [StringLength(7)]
        public string ExprDate { get; set; }

        [Required]
        [StringLength(40)]
        public string CardType { get; set; }

        [Required]
        [StringLength(20)]
        public string Locale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineItem> LineItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderStatu> OrderStatus { get; set; }
    }
}
