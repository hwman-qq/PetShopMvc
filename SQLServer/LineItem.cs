namespace PetShop.Data.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LineItem")]
    public partial class LineItem
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LineNum { get; set; }

        [Required]
        [StringLength(10)]
        public string ItemId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual Order Order { get; set; }
    }
}
