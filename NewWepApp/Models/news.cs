namespace NewWepApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {

        [Display(Name ="News Id")]
        public int newsId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage ="*")]
        public string title { get; set; }

        [Required(ErrorMessage ="*")]
        public string brief { get; set; }

        [Required(ErrorMessage = "*")]
        public string description { get; set; }

        [Required(ErrorMessage = "*")]
        public DateTime? datetime { get; set; }

        [Required(ErrorMessage = "*")]
        public string photo { get; set; }

        [Display(Name ="user Id")]
        public int? userId { get; set; }

        [Display(Name = "category Id")]
        public int? categoryId { get; set; }

        public virtual category category { get; set; }

        public virtual user user { get; set; }
    }
}
