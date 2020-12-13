namespace NewWepApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            news = new HashSet<news>();
        }
        [Display(Name ="user id")]
        public int userId { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="*")]
        [Remote("check", "user", ErrorMessage = "Exist Email !", AdditionalFields = "userId")]

        public string userName { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="*")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",ErrorMessage ="invaild email")]
        public string email { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="*")]
        public string password { get; set; }

        [NotMapped]
        [Display(Name ="Confirm Password")]
        //[Compare("password",ErrorMessage ="Password not match")]
        public string confirm_password { get; set; }

        [Required(ErrorMessage ="*")]
        public string photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<news> news { get; set; }
    }
}
