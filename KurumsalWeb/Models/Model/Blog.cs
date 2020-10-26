using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogName { get; set; }
        public string BlogContent { get; set; }
        public string ImageURL { get; set; }
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<Comment> Comments  { get; set; }
    }
}