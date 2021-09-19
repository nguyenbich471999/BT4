namespace BT4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Acount")]
    public partial class Acount
    {
        [Key]
        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(10)]
        public string Password { get; set; }
    }
}
