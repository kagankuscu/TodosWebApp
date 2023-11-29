using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodosWebApp.Model.Entities;

namespace TodosWebApp.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost; Database=TodoDB; User Id=SA; Password=reallyStrongPwd123;TrustServerCertificate=True;MultiSubnetFailover=True;");
        }

        public DbSet<Todo> Todos { get; set; }
    }
}