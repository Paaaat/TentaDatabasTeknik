namespace TentaDatabasTeknik.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductPriceChanx
    {
        [Key]
        public int ProductPriceChangeID { get; set; }

        public int ProductID { get; set; }

        [Column(TypeName = "money")]
        public decimal OldPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal NewPrice { get; set; }

        public DateTime ChangedDate { get; set; }

        public int UserId { get; set; }
    }
}
