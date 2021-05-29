using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pagination.Models
{
    public class StudentDbcontext:DbContext
    {

        public DbSet<Student> Students { get; set; }
        public StudentDbcontext(DbContextOptions<StudentDbcontext> options):base(options)
        {
            
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            
        }
    }
}