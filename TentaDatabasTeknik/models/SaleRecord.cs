namespace TentaDatabasTeknik.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaleRecord")]
    public partial class SaleRecord
    {
        [StringLength(50)]
        public string Produkter { get; set; }

        [Key]
        public int Antal { get; set; }
    }
}
