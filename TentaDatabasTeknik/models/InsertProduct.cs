namespace TentaDatabasTeknik.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InsertProduct")]
    public partial class InsertProduct
    {
        [Key]
        [StringLength(10)]
        public string ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int ProductPrice { get; set; }
    }
}
