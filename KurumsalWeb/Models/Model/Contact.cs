using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(250,ErrorMessage ="Max 250 Characters")]
        public string Address { get; set; }
        [StringLength(250, ErrorMessage = "Max 250 Characters")]
        public string Phone { get; set; }
        [StringLength(250, ErrorMessage = "Max 250 Characters")]
        public string Fax { get; set; }
        [StringLength(250, ErrorMessage = "Max 250 Characters")]
        public string Whatsapp { get; set; }
        [StringLength(250, ErrorMessage = "Max 250 Characters")]
        public string Facebook { get; set; }
        [StringLength(250, ErrorMessage = "Max 250 Characters")]
        public string Twitter { get; set; }
        [StringLength(250, ErrorMessage = "Max 250 Characters")]
        public string Instagran { get; set; }

    }
}