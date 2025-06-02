using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Repair3v.Models
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DBSrv\\gor2024;Database=Ponomaryovadb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
