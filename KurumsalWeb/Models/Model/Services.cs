using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Services")]
    public class Services
    {
        [Key]
        public int ServiceID { get; set; }
        [Required,StringLength(150,ErrorMessage ="Max 150 Characters")]
        [DisplayName("Service Name")]
        public string ServiceName { get; set; }
        public string Description { get; set; }
        [DisplayName("Service Image")]
        public string ImageURL { get; set; }

    }
}