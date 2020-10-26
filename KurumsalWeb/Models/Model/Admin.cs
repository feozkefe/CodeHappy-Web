using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required,StringLength(50,ErrorMessage ="Max 50 character")]
        public string Email { get; set; }
        [Required,StringLength(50,ErrorMessage = "Max 50 character")]
        public string Password { get; set; }
        public string Authority { get; set; }
    }
}