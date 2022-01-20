namespace BTLVinamilk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUA")]
    public partial class SUA
    {
        [DisplayName("Mã sữa")]
        public int ID { get; set; }
        [Required(ErrorMessage ="Tên sữa không được để trống!")]
        [StringLength(50)]
        [DisplayName("Tên sữa")]
        public string TieuDe { get; set; }

        [StringLength(50)]
        [DisplayName("Ảnh bìa sữa")]
        public string AnhBia { get; set; }
        [DisplayName("Số lượng")]
        public int? SoLuong { get; set; }

        [Column(TypeName = "money")]
        [DisplayName("Giá bán")]
        public decimal? GiaBan { get; set; }
        [DisplayName("Mô tả")]
        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage ="Mã danh mục không được để trống!")]
        [DisplayName("Mã danh mục")]
        public string IDDM { get; set; }

        public virtual DMSUA DMSUA { get; set; }
    }
}
