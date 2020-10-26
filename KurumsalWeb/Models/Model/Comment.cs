using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [Required,StringLength(50,ErrorMessage ="Max 50 Characters.")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string CommentContent { get; set; }
        public bool confirmed { get; set; }
        public int? BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}