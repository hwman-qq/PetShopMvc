namespace PetShop.Data.SqlServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventory")]
    public partial class Inventory
    {
        [Key]
        [StringLength(10)]
        public string ItemId { get; set; }

        public int Qty { get; set; }
    }
}
