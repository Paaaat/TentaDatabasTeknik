namespace TentaDatabasTeknik.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CategoryChanx
    {
        [Key]
        public int CategoryChangeID { get; set; }

        public int CategoryID { get; set; }

        [StringLength(15)]
        public string OldCategoryName { get; set; }

        [StringLength(15)]
        public string NewCategoryName { get; set; }
    }
}
