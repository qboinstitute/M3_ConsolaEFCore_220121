using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace M3_ConsolaEFCore.CodeFirst.Models
{
    public class FifaDBContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string myConnectionString = "Server=DESKTOP-S1DROK0\\SQLEXPRESS;Database=FifaDB;Trusted_Connection=true;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(myConnectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }


    }
}
