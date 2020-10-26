using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int SliderID { get; set; }
        [DisplayName("Slider Name"),StringLength(30,ErrorMessage ="Max 30 Characters")]
        public string SliderName { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}