namespace PetShop.Data.SqlServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [Key]
        [StringLength(20)]
        public string UserId { get; set; }

        [Required]
        [StringLength(80)]
        public string Email { get; set; }

        [Required]
        [StringLength(80)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80)]
        public string LastName { get; set; }

        [StringLength(2)]
        public string Status { get; set; }

        [Required]
        [StringLength(80)]
        public string Addr1 { get; set; }

        [StringLength(80)]
        public string Addr2 { get; set; }

        [Required]
        [StringLength(80)]
        public string City { get; set; }

        [Required]
        [StringLength(80)]
        public string State { get; set; }

        [Required]
        [StringLength(20)]
        public string Zip { get; set; }

        [Required]
        [StringLength(20)]
        public string Country { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
    }
}
