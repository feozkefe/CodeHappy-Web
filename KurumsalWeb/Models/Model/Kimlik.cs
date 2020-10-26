using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Kimlik")]
    public class Kimlik
    {
        [Key]
        public int KimlikID { get; set; }
        [DisplayName("Website Name")]
        [Required,StringLength(100,ErrorMessage ="Max 100 Characters")]
        public string Title { get; set; }
        [DisplayName("Keywords")]
        [Required, StringLength(200, ErrorMessage = "Max 200 Characters")]
        public string Keywords { get; set; }
        [Required, StringLength(500, ErrorMessage = "Max 500 Characters")]
        public string Description { get; set; }
        [DisplayName("Website Logo")]
        public int LogoURL { get; set; }
        [DisplayName("Authority Level")]
        public int Unvan { get; set; }
    }
}