namespace TentaDatabasTeknik.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InsertCustomer")]
    public partial class InsertCustomer
    {
        [Key]
        [StringLength(10)]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(50)]
        public string ContactName { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}
