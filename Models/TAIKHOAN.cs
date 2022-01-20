namespace BTLVinamilk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [Key]
        [StringLength(10)]
        public string Ten { get; set; }

        [StringLength(10)]
        public string MatKhau { get; set; }

        [StringLength(10)]
        public string QuenTC { get; set; }
    }
}
