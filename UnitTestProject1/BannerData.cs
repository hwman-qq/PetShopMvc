namespace UnitTestProject1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BannerData")]
    public partial class BannerData
    {
        [Key]
        [StringLength(80)]
        public string FavCategory { get; set; }

        [Column("BannerData")]
        [StringLength(255)]
        public string BannerData1 { get; set; }
    }
}
