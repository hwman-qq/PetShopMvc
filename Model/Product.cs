namespace PetShop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
        }

        [StringLength(10)]
        public string ProductId { get; set; }

        [Required]
        [StringLength(10)]
        public string Category { get; set; }

        [StringLength(80)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Descn { get; set; }

        public virtual Category ProductCategory { get; set; }

    }
}
