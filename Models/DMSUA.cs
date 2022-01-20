namespace BTLVinamilk.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMSUA")]
    public partial class DMSUA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMSUA()
        {
            SUAs = new HashSet<SUA>();
        }

        [Key]
        [StringLength(10)]
        [Required(ErrorMessage ="Mã danh mục không được để trống!")]
        public string IDDM { get; set; }
        [Required(ErrorMessage ="Tên danh mục không được để trống!")]
        [StringLength(20)]
        [DisplayName("Tên danh mục")]
        public string TenDM { get; set; }

        [StringLength(50)]
        [DisplayName("Ảnh danh mục")]
        public string AnhDM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUA> SUAs { get; set; }
    }
}
