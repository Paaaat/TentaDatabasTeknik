namespace TentaDatabasTeknik.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UpdateProduct
    {
        [Key]
        [StringLength(10)]
        public string ChangedProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ChangedProductName { get; set; }

        public int ChangedProductPrice { get; set; }

        [Required]
        [StringLength(10)]
        public string ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        public int ProductPrice { get; set; }
    }
}
