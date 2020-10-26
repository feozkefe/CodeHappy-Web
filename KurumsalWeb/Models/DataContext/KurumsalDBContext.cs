using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.DataContext
{
    public class KurumsalDBContext:DbContext
    {
        public KurumsalDBContext():base("KurumsalWebDB")
        {

        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Kimlik> Kimlik { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}