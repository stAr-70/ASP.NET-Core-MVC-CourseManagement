using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sarah10415_MVC.Models
{
    public class SarahDbContext :DbContext
    {
        public SarahDbContext() :base("DbConnectionString")
        {

        }

        public DbSet <Room> rooms { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Course> courses { get; set; }

    }
}