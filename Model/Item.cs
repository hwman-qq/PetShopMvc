namespace PetShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        [StringLength(10)]
        public string ItemId { get; set; }

        [Required]
        [StringLength(10)]
        public string ProductId { get; set; }

        public decimal? ListPrice { get; set; }

        public decimal? UnitCost { get; set; }

        public int? Supplier { get; set; }

        [StringLength(2)]
        public string Status { get; set; }

        [StringLength(80)]
        public string Attr1 { get; set; }

        [StringLength(80)]
        public string Attr2 { get; set; }

        [StringLength(80)]
        public string Attr3 { get; set; }

        [StringLength(80)]
        public string Attr4 { get; set; }

        [StringLength(80)]
        public string Attr5 { get; set; }

        public virtual Product Product { get; set; }

        public virtual Supplier Supplier1 { get; set; }
    }
}
