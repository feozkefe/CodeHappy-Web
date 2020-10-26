using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required,StringLength(50,ErrorMessage ="Max 50 Characters")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<Blog> Blog  { get; set; }
    }
}