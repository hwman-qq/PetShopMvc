namespace UnitTestProject1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Profile")]
    public partial class Profile
    {
        [Key]
        [StringLength(20)]
        public string UserId { get; set; }

        [Required]
        [StringLength(80)]
        public string LangPref { get; set; }

        [StringLength(30)]
        public string FavCategory { get; set; }

        public int? MyListOpt { get; set; }

        public int? BannerOpt { get; set; }
    }
}
